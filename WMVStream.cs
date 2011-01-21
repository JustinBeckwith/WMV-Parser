using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using com.jbeckwith.wmv.ASFObjects;

namespace com.jbeckwith.wmv
{
	/// <summary>
	/// 
	/// </summary>
	public class WMVStream
	{
		//--------------------------------------------------------------------------
		//
		//  Variables
		//
		//--------------------------------------------------------------------------

		#region Variables

		protected FileStream _fileStream;

		#endregion



		//--------------------------------------------------------------------------
		//
		//  Constructors
		//
		//--------------------------------------------------------------------------

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		public WMVStream(string path)
		{
			_fileStream = new FileStream(path, FileMode.Open);			
		}
		#endregion


		//--------------------------------------------------------------------------
		//
		//  Methods
		//
		//--------------------------------------------------------------------------

		#region ReadNext
		/// <summary>
		/// read the next object off of the stream
		/// </summary>
		/// <returns></returns>
		public WMVStruct ReadNext()
		{
			if (_fileStream.CanRead)
			{
				// the first 16 bytes is always an object Id
				Byte[] buffer = new Byte[16];
				_fileStream.Read(buffer, 0, buffer.Length);
				Guid objectId = new Guid(buffer);

				// the next 8 bytes are always the object length
				buffer = new Byte[8];
				_fileStream.Read(buffer, 0, buffer.Length);
				UInt64 objectSize = BitConverter.ToUInt64(buffer, 0);

				// create a new struct and optionally parse the data
				WMVStruct obj = WMVStruct.CreateObject(objectId);
				obj.ObjectId = objectId;
				obj.ObjectSize = objectSize;
				obj.ParseStruct(_fileStream, objectSize);

				// return the parsed WMVStruct object
				return obj;
			}
			else
			{
				return null;
			}
		}
		#endregion

		#region GetDuration
		/// <summary>
		/// for the love of god this was all I wanted all along.  Returns the duration of the wmv in milliseconds
		/// </summary>
		/// <returns></returns>
		public UInt64 GetDuration()
		{
			WMVStruct obj = null;
			UInt64 duration = 0;

			do
			{
				obj = this.ReadNext();
				if (obj is ASF_File_Properties_Object)
				{
					ASF_File_Properties_Object fpo = (ASF_File_Properties_Object)obj;
					// duration is really the duration minus and pre-roll field defined for buffering (that was fun to find). 
					// also duration is stored in 100 nano-second units, and pre-roll in milliseconds
					duration = ((fpo.PlayDuration/10000) - fpo.Preroll);
					break;
				}
			} while (obj != null);			
			_fileStream.Close();

			return duration;
		}

		#endregion
	}
}

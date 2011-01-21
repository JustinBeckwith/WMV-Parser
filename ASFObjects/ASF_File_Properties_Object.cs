using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace com.jbeckwith.wmv.ASFObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class ASF_File_Properties_Object : WMVStruct 
	{
		//--------------------------------------------------------------------------
		//
		//  Properties
		//
		//--------------------------------------------------------------------------	
		
		public Guid FileID { get; set; }
		public UInt64 FileSize { get; set; }
		public UInt64 CreationDate { get; set; }
		public UInt64 DataPacketsCount { get; set; }
		public UInt64 PlayDuration { get; set; }
		public UInt64 SendDuration { get; set; }
		public UInt64 Preroll { get; set; }
		public Flags Flags { get; set; }
		public UInt32 MinimumDataPacketSize { get; set; }
		public UInt32 MaximumDataPacketSize { get; set; }
		public UInt32 MaximimBitrate { get; set; }		

		//--------------------------------------------------------------------------
		//
		//  Methods
		//
		//--------------------------------------------------------------------------

		#region ParseStruct
		/// <summary>
		/// for the header object, we actually want to read the data that's passed in
		/// </summary>
		public override void ParseStruct(FileStream fs, UInt64 objectSize)
		{
			ulong bytesRead = 0;

			// read FileId
			Byte[] buffer = new Byte[16];
			fs.Read(buffer, 0, buffer.Length);
			this.FileID = new Guid(buffer);
			bytesRead += 16;

			// file size
			buffer = new Byte[8];
			fs.Read(buffer, 0, buffer.Length);
			this.FileSize = BitConverter.ToUInt64(buffer, 0);
			bytesRead += 8;

			// creation date
			buffer = new Byte[8];
			fs.Read(buffer, 0, buffer.Length);
			this.CreationDate = BitConverter.ToUInt64(buffer, 0);
			bytesRead += 8;

			// data packets count
			buffer = new Byte[8];
			fs.Read(buffer, 0, buffer.Length);
			this.DataPacketsCount = BitConverter.ToUInt64(buffer, 0);
			bytesRead += 8;

			// Play Duration
			buffer = new Byte[8];
			fs.Read(buffer, 0, buffer.Length);
			this.PlayDuration = BitConverter.ToUInt64(buffer, 0);
			bytesRead += 8;

			// send duration
			buffer = new Byte[8];
			fs.Read(buffer, 0, buffer.Length);
			this.SendDuration = BitConverter.ToUInt64(buffer, 0);
			bytesRead += 8;

			// Preroll
			buffer = new Byte[8];
			fs.Read(buffer, 0, buffer.Length);
			this.Preroll = BitConverter.ToUInt64(buffer, 0);
			bytesRead += 8;

			// flags
			buffer = new Byte[4];
			fs.Read(buffer, 0, buffer.Length);
			this.Flags = new Flags()
			{
				BroadcastFlag = false,
				SeekableFlag = false,
				Reserved = buffer
			};
			bytesRead += 4;

			// Minimum data packet size
			buffer = new Byte[4];
			fs.Read(buffer, 0, buffer.Length);
			this.MinimumDataPacketSize = BitConverter.ToUInt32(buffer, 0);
			bytesRead += 4;

			// maxmimum data packet size
			buffer = new Byte[4];
			fs.Read(buffer, 0, buffer.Length);
			this.MaximumDataPacketSize = BitConverter.ToUInt32(buffer, 0);
			bytesRead += 4;

			// maximum bitrate
			buffer = new Byte[4];
			fs.Read(buffer, 0, buffer.Length);
			this.MaximimBitrate = BitConverter.ToUInt32(buffer, 0);
			bytesRead += 4;

			if (bytesRead != (objectSize-24))
				throw new Exception("Bytes read does not match object size");
			
		}
		#endregion
	}

	public class Flags
	{
		public bool BroadcastFlag { get; set; }
		public bool SeekableFlag { get; set; }
		public byte[] Reserved { get; set; }
	}
}

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
	public class ASF_Header_Object : WMVStruct 
	{
		//--------------------------------------------------------------------------
		//
		//  Properties
		//
		//--------------------------------------------------------------------------	
		
		public UInt32 NumberofHeaderObjects { get; set; }
		public Byte Reserved1 { get; set; }
		public Byte Reserved2 { get; set; }


		public ASF_File_Properties_Object ASF_File_Properties_Object { get; set; }
		public ASF_Stream_Properties_Object ASF_Stream_Properties_Object { get; set; }
		public ASF_Header_Extension_Object ASF_Header_Extension_Object{ get; set; }
		public ASF_Codec_List_Object ASF_Codec_List_Object{ get; set; }
		public ASF_Script_Command_Object ASF_Script_Command_Object{ get; set; }
		public ASF_Marker_Object ASF_Marker_Object{ get; set; }
		public ASF_Bitrate_Mutual_Exclusion_Object ASF_Bitrate_Mutual_Exclusion_Object{ get; set; }
		public ASF_Error_Correction_Object ASF_Error_Correction_Object{ get; set; }
		public ASF_Content_Description_Object ASF_Content_Description_Object{ get; set; }
		public ASF_Extended_Content_Description_Object ASF_Extended_Content_Description_Object{ get; set; }
		public ASF_Content_Branding_Object ASF_Content_Branding_Object{ get; set; }
		public ASF_Stream_Bitrate_Properties_Object ASF_Stream_Bitrate_Properties_Object{ get; set; }
		public ASF_Content_Encryption_Object ASF_Content_Encryption_Object{ get; set; }
		public ASF_Extended_Content_Encryption_Object ASF_Extended_Content_Encryption_Object{ get; set; }
		public ASF_Digital_Signature_Object ASF_Digital_Signature_Object{ get; set; }
		public ASF_Padding_Object ASF_Padding_Object { get; set; }

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
			// read number of hjeader objects
			Byte[] buffer = new Byte[4];
			fs.Read(buffer, 0, buffer.Length);
			this.NumberofHeaderObjects = BitConverter.ToUInt32(buffer, 0);

			// snag the reserved flags
			this.Reserved1 = (Byte)fs.ReadByte();
			this.Reserved2 = (Byte)fs.ReadByte();
		}
		#endregion
	}

	// header classes	
	public class ASF_Stream_Properties_Object : WMVStruct { }
	public class ASF_Codec_List_Object : WMVStruct { }
	public class ASF_Script_Command_Object : WMVStruct { }
	public class ASF_Marker_Object : WMVStruct { }
	public class ASF_Bitrate_Mutual_Exclusion_Object : WMVStruct { }
	public class ASF_Error_Correction_Object : WMVStruct { }
	public class ASF_Content_Description_Object : WMVStruct { }
	public class ASF_Extended_Content_Description_Object : WMVStruct { }
	public class ASF_Content_Branding_Object : WMVStruct { }
	public class ASF_Stream_Bitrate_Properties_Object : WMVStruct { }
	public class ASF_Content_Encryption_Object : WMVStruct { }
	public class ASF_Extended_Content_Encryption_Object : WMVStruct { }
	public class ASF_Digital_Signature_Object : WMVStruct { }
	public class ASF_Padding_Object : WMVStruct { }			
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace com.jbeckwith.wmv
{
	/// <summary>
	/// base class for a read structure from a wmv file
	/// </summary>
	public class WMVStruct
	{
		//--------------------------------------------------------------------------
		//
		//  Properties
		//
		//--------------------------------------------------------------------------

		#region Properties

		public static IDictionary<Guid, string> ObjectHash = new Dictionary<Guid, string>() { 
			
			// top level guids
			{new Guid("75B22630-668E-11CF-A6D9-00AA0062CE6C"), "ASF_Header_Object"},
			{new Guid("75B22636-668E-11CF-A6D9-00AA0062CE6C"), "ASF_Data_Object"},
			{new Guid("33000890-E5B1-11CF-89F4-00A0C90349CB"), "ASF_Simple_Index_Object"},
			{new Guid("D6E229D3-35DA-11D1-9034-00A0C90349BE"), "ASF_Index_Object"},
			{new Guid("FEB103F8-12AD-4C64-840F-2A1D2F7AD48C"), "ASF_Media_Object_Index_Object"},
			{new Guid("3CB73FD0-0C4A-4803-953D-EDF7B6228F0C"), "ASF_Timecode_Index_Object"},
		
			//10.2 Header Object GUIDs
			//The following table contains the names and values of standard ASF Header Object GUIDs.
		
			{new Guid("8CABDCA1-A947-11CF-8EE4-00C00C205365"), "ASF_File_Properties_Object"},
			{new Guid("B7DC0791-A9B7-11CF-8EE6-00C00C205365"), "ASF_Stream_Properties_Object"},
			{new Guid("5FBF03B5-A92E-11CF-8EE3-00C00C205365"), "ASF_Header_Extension_Object"},
			{new Guid("86D15240-311D-11D0-A3A4-00A0C90348F6"), "ASF_Codec_List_Object"},
			{new Guid("1EFB1A30-0B62-11D0-A39B-00A0C90348F6"), "ASF_Script_Command_Object"},
			{new Guid("F487CD01-A951-11CF-8EE6-00C00C205365"), "ASF_Marker_Object"},
			{new Guid("D6E229DC-35DA-11D1-9034-00A0C90349BE"), "ASF_Bitrate_Mutual_Exclusion_Object"},
			{new Guid("75B22635-668E-11CF-A6D9-00AA0062CE6C"), "ASF_Error_Correction_Object"},
			{new Guid("75B22633-668E-11CF-A6D9-00AA0062CE6C"), "ASF_Content_Description_Object"},
			{new Guid("D2D0A440-E307-11D2-97F0-00A0C95EA850"), "ASF_Extended_Content_Description_Object"},
			{new Guid("2211B3FA-BD23-11D2-B4B7-00A0C955FC6E"), "ASF_Content_Branding_Object"},
			{new Guid("7BF875CE-468D-11D1-8D82-006097C9A2B2"), "ASF_Stream_Bitrate_Properties_Object"},
			{new Guid("2211B3FB-BD23-11D2-B4B7-00A0C955FC6E"), "ASF_Content_Encryption_Object"},
			{new Guid("298AE614-2622-4C17-B935-DAE07EE9289C"), "ASF_Extended_Content_Encryption_Object"},
			{new Guid("2211B3FC-BD23-11D2-B4B7-00A0C955FC6E"), "ASF_Digital_Signature_Object"},
			{new Guid("1806D474-CADF-4509-A4BA-9AABCB96AAE8"), "ASF_Padding_Object"},
		
			//10.3 Header Extension Object GUIDs
			//The following table contains the names and values of the GUIDs for the standard objects found inside the ASF Header Extension Object.
		
			{new Guid("14E6A5CB-C672-4332-8399-A96952065B5A"), "ASF_Extended_Stream_Properties_Object"},
			{new Guid("A08649CF-4775-4670-8A16-6E35357566CD"), "ASF_Advanced_Mutual_Exclusion_Object"},
			{new Guid("D1465A40-5A79-4338-B71B-E36B8FD6C249"), "ASF_Group_Mutual_Exclusion_Object"},
			{new Guid("D4FED15B-88D3-454F-81F0-ED5C45999E24"), "ASF_Stream_Prioritization_Object"},
			{new Guid("A69609E6-517B-11D2-B6AF-00C04FD908E9"), "ASF_Bandwidth_Sharing_Object"},
			{new Guid("7C4346A9-EFE0-4BFC-B229-393EDE415C85"), "ASF_Language_List_Object"},
			{new Guid("C5F8CBEA-5BAF-4877-8467-AA8C44FA4CCA"), "ASF_Metadata_Object"},
			{new Guid("44231C94-9498-49D1-A141-1D134E457054"), "ASF_Metadata_Library_Object"},
			{new Guid("D6E229DF-35DA-11D1-9034-00A0C90349BE"), "ASF_Index_Parameters_Object"},
			{new Guid("6B203BAD-3F11-48E4-ACA8-D7613DE2CFA7"), "ASF_Media_Object_Index_Parameters_Object"},
			{new Guid("F55E496D-9797-4B5D-8C8B-604DFE9BFB24"), "ASF_Timecode_Index_Parameters_Object"},
			{new Guid("26F18B5D-4584-47EC-9F5F-0E651F0452C9"), "ASF_Compatibility_Object"},
			{new Guid("43058533-6981-49E6-9B74-AD12CB86D58C"), "ASF_Advanced_Content_Encryption_Object"}

		};

		#endregion
		
		//--------------------------------------------------------------------------
		//
		//  Properties
		//
		//--------------------------------------------------------------------------

		#region Properties

		/// <summary>
		/// guid that maps to the object type in the ObjectHash abobe
		/// </summary>
		public Guid ObjectId { get; set; }

		/// <summary>
		/// number of bytes to read for the given object
		/// </summary>
		public UInt64 ObjectSize { get; set; }

		#endregion

		//--------------------------------------------------------------------------
		//
		//  Static Methods
		//
		//--------------------------------------------------------------------------

		#region GetObjectType
		/// <summary>
		/// get the type based on the object guid
		/// </summary>
		/// <param name="objectId"></param>
		/// <returns></returns>
		public static Type GetObjectType(Guid objectId)
		{
			string typeString = WMVStruct.ObjectHash[objectId];
			Type t = Type.GetType("vte.utilities.wmv.ASFObjects." + typeString);
			return t;
		}
		#endregion

		#region CreateObject
		/// <summary>
		/// 
		/// </summary>
		/// <param name="objectId"></param>
		/// <returns></returns>
		public static WMVStruct CreateObject(Guid objectId)
		{
			Type t = WMVStruct.GetObjectType(objectId);
			return (WMVStruct)Activator.CreateInstance(t);
		}
		#endregion

		//--------------------------------------------------------------------------
		//
		//  Methods
		//
		//--------------------------------------------------------------------------		
		
		#region ParseStruct
		/// <summary>
		/// this should be abstract.  If the WMVStruct inheriting object doesn't implement this method, it won't get the data,
		/// but this method is required to at least read the data off of the buffer
		/// </summary>
		public virtual void ParseStruct(FileStream fs, UInt64 objectSize)
		{
			// this should be thrown if I decide to write a real asf parser, but for now I just want to ignore this if it isn't implemented

			// since this isn't implemented, just read the bits and dump the data
			Byte[] buffer = new Byte[objectSize - 24];
			fs.Read(buffer, 0, buffer.Length);

			//throw new NotImplementedException("Read struct not implemented!");
		}
		#endregion

	}
}

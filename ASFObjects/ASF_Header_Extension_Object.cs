using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.jbeckwith.wmv.ASFObjects
{
	//--------------------------------------------------------------------------
	//
	//  Top Level Objects
	//
	//--------------------------------------------------------------------------	

	public class ASF_Header_Extension_Object : WMVStruct 
	{
		public ASF_Extended_Stream_Properties_Object ASF_Extended_Stream_Properties_Object { get; set; }
		public ASF_Advanced_Mutual_Exclusion_Object ASF_Advanced_Mutual_Exclusion_Object { get; set; }
		public ASF_Group_Mutual_Exclusion_Object ASF_Group_Mutual_Exclusion_Object { get; set; }
		public ASF_Stream_Prioritization_Object ASF_Stream_Prioritization_Object { get; set; }
		public ASF_Bandwidth_Sharing_Object ASF_Bandwidth_Sharing_Object { get; set; }
		public ASF_Language_List_Object ASF_Language_List_Object { get; set; }
		public ASF_Metadata_Object ASF_Metadata_Object { get; set; }
		public ASF_Metadata_Library_Object ASF_Metadata_Library_Object { get; set; }
		public ASF_Index_Parameters_Object ASF_Index_Parameters_Object { get; set; }
		public ASF_Media_Object_Index_Parameters_Object ASF_Media_Object_Index_Parameters_Object { get; set; }
		public ASF_Timecode_Index_Parameters_Object ASF_Timecode_Index_Parameters_Object { get; set; }
		public ASF_Compatibility_Object ASF_Compatibility_Object { get; set; }
		public ASF_Advanced_Content_Encryption_Object ASF_Advanced_Content_Encryption_Object { get; set; }


		
	}

	// header extension classes
	public class ASF_Extended_Stream_Properties_Object : WMVStruct { }
	public class ASF_Advanced_Mutual_Exclusion_Object : WMVStruct { }
	public class ASF_Group_Mutual_Exclusion_Object : WMVStruct { }
	public class ASF_Stream_Prioritization_Object : WMVStruct { }
	public class ASF_Bandwidth_Sharing_Object : WMVStruct { }
	public class ASF_Language_List_Object : WMVStruct { }
	public class ASF_Metadata_Object : WMVStruct { }
	public class ASF_Metadata_Library_Object : WMVStruct { }
	public class ASF_Index_Parameters_Object : WMVStruct { }
	public class ASF_Media_Object_Index_Parameters_Object : WMVStruct { }
	public class ASF_Timecode_Index_Parameters_Object : WMVStruct { }
	public class ASF_Compatibility_Object : WMVStruct { }
	public class ASF_Advanced_Content_Encryption_Object : WMVStruct { }
}

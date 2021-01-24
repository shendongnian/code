       /* 
        Licensed under the Apache License, Version 2.0
        
        http://www.apache.org/licenses/LICENSE-2.0
        */
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
    	[XmlRoot(ElementName="Content")]
    	public class Content {
    		[XmlElement(ElementName="UId")]
    		public string UId { get; set; }
    		[XmlElement(ElementName="FileName")]
    		public string FileName { get; set; }
    		[XmlElement(ElementName="Image")]
    		public string Image { get; set; }
    		[XmlElement(ElementName="FullPath")]
    		public List<string> FullPath { get; set; }
    	}
    
    	[XmlRoot(ElementName="root")]
    	public class Root {
    		[XmlElement(ElementName="Content")]
    		public List<Content> Content { get; set; }
    	}
    
    }

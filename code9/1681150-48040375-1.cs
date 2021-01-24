       /* 
        Licensed under the Apache License, Version 2.0
        
        http://www.apache.org/licenses/LICENSE-2.0
        */
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
    	[XmlRoot(ElementName="Camera")]
    	public class Camera {
    		[XmlAttribute(AttributeName="Name")]
    		public string Name { get; set; }
    		[XmlAttribute(AttributeName="Url")]
    		public string Url { get; set; }
    		[XmlAttribute(AttributeName="Width")]
    		public string Width { get; set; }
    		[XmlAttribute(AttributeName="Height")]
    		public string Height { get; set; }
    	}
    
    	[XmlRoot(ElementName="Cameras")]
    	public class Cameras {
    		[XmlElement(ElementName="Camera")]
    		public List<Camera> Camera { get; set; }
    	}
    
    	[XmlRoot(ElementName="Configuration")]
    	public class Configuration {
    		[XmlElement(ElementName="Cameras")]
    		public Cameras Cameras { get; set; }
    	}
    
    }

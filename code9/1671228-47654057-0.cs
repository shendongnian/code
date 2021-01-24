    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
    	[XmlRoot(ElementName="Row")]
    	public class Row {
    		[XmlElement(ElementName="APPROVER")]
    		public string APPROVER { get; set; }
    		[XmlElement(ElementName="LEVEL")]
    		public string LEVEL { get; set; }
    		[XmlElement(ElementName="LEVELDECODE")]
    		public string LEVELDECODE { get; set; }
    	}
    
    	[XmlRoot(ElementName="DataSet")]
    	public class DataSet {
    		[XmlElement(ElementName="Row")]
    		public List<Row> Row { get; set; }
    	}
    
    }

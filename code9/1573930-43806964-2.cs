    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace XmlSerialize
    {
    	[XmlRoot(ElementName="push")]
    	public class Push {
    		[XmlAttribute(AttributeName="cert_num")]
    		public string Cert_num { get; set; }
    		[XmlAttribute(AttributeName="pre")]
    		public string Pre { get; set; }
    		[XmlAttribute(AttributeName="code")]
    		public string Code { get; set; }
    		[XmlAttribute(AttributeName="post")]
    		public string Post { get; set; }
    	}
    
    	[XmlRoot(ElementName="request")]
    	public class Request {
    		[XmlElement(ElementName="push")]
    		public Push Push { get; set; }
    		[XmlAttribute(AttributeName="subject")]
    		public string Subject { get; set; }
    		[XmlAttribute(AttributeName="action")]
    		public string Action { get; set; }
    		[XmlAttribute(AttributeName="id")]
    		public string Id { get; set; }
    	}
    
    	[XmlRoot(ElementName="epolice")]
    	public class Epolice {
    		[XmlElement(ElementName="request")]
    		public Request Request { get; set; }
    		[XmlElement(ElementName="signature")]
    		public string Signature { get; set; }
    	}
    
    }

    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
    	[XmlRoot(ElementName="return")]
    	public class Return {
    		[XmlElement(ElementName="errorID")]
    		public string ErrorID { get; set; }
    	}
	[XmlRoot(ElementName="getBillsResponse", Namespace="http://obrs/")]
	public class GetBillsResponse {
		[XmlElement(ElementName="return")]
		public Return Return { get; set; }
		[XmlAttribute(AttributeName="ns2", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Ns2 { get; set; }
	}
	[XmlRoot(ElementName="Body", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
	public class Body {
		[XmlElement(ElementName="getBillsResponse", Namespace="http://obrs/")]
		public GetBillsResponse GetBillsResponse { get; set; }
	}
	[XmlRoot(ElementName="Envelope", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
	public class Envelope {
		[XmlElement(ElementName="Body", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
		public Body Body { get; set; }
		[XmlAttribute(AttributeName="S", Namespace="http://www.w3.org/2000/xmlns/")]
		public string S { get; set; }
	}
}

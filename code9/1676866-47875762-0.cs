				using System;
				using System.Xml.Serialization;
				using System.Collections.Generic;
				
				namespace Xml2CSharp
				{
					[XmlRoot(ElementName = "GetResult", Namespace = "http://ws.design.americaneagle.com")]
					public class GetResult
					{
						[XmlElement(ElementName = "Distance", Namespace = "http://ws.design.americaneagle.com")]
						public string Distance { get; set; }
				
						[XmlElement(ElementName = "ID", Namespace = "http://ws.design.americaneagle.com")]
						public string ID { get; set; }
				
						[XmlElement(ElementName = "Name", Namespace = "http://ws.design.americaneagle.com")]
						public string Name { get; set; }
				
						[XmlElement(ElementName = "Code", Namespace = "http://ws.design.americaneagle.com")]
						public string Code { get; set; }
				
						[XmlElement(ElementName = "Address1", Namespace = "http://ws.design.americaneagle.com")]
						public string Address1 { get; set; }
					}
				
					[XmlRoot(ElementName = "GetResponse", Namespace = "http://ws.design.americaneagle.com")]
					public class GetResponse
					{
						[XmlElement(ElementName = "GetResult", Namespace = "http://ws.design.americaneagle.com")]
						public GetResult GetResult { get; set; }
				
						[XmlAttribute(AttributeName = "xmlns")]
						public string Xmlns { get; set; }
					}
				
					[XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
					public class Body
					{
						[XmlElement(ElementName = "GetResponse", Namespace = "http://ws.design.americaneagle.com")]
						public GetResponse GetResponse { get; set; }
					}
				
					[XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
					public class Envelope
					{
						[XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
						public Body Body { get; set; }
				
						[XmlAttribute(AttributeName = "soap", Namespace = "http://www.w3.org/2000/xmlns/")]
						public string Soap { get; set; }
				
						[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
						public string Xsi { get; set; }
				
						[XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
						public string Xsd { get; set; }
					}
				}

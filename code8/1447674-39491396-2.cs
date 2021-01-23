    [XmlRoot(ElementName="payload")]
        public class Payload {
        	[XmlElement(ElementName="firstname")]
        	public string Firstname { get; set; }
        	[XmlElement(ElementName="secondname")]
        	public string Secondname { get; set; }
        	[XmlElement(ElementName="number")]
        	public string Number { get; set; }
        }
        
        [XmlRoot(ElementName="payloads")]
        public class Payloads {
        	[XmlElement(ElementName="payload")]
        	public List<Payload> Payload { get; set; }
        }

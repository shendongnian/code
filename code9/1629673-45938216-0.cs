	[XmlRoot(ElementName="signOnResponse", Namespace="http://tempuri.org/")]
	public class SignOnResponse {
		[XmlElement(ElementName="signOnResult", Namespace="http://tempuri.org/")]
		public List<string> SignOnResult { get; set; }
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }
	}

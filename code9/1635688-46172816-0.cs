	var serializer = new XmlSerializer(typeof(SomeModel), new XmlRootAttribute("TASubmittedFileDT"));
	var doc = XDocument.Load("example.xml");
	var resultingMessage = (SomeModel)serializer.Deserialize(doc.CreateReader());
	[XmlRoot(ElementName = "TASubmittedFileDT")]
	public class SomeModel
	{
		public string EntityId { get; set; }
		public string EntityName { get; set; }
		public int YA { get; set; }
		public string ReasonText { get; set; }
	}

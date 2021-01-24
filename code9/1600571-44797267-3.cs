	public class CustomXmlFormatter : XmlMediaTypeFormatter
	{
		public XmlSerializerNamespaces Namespaces { get; }
		public CustomXmlFormatter()
		{
			Namespaces = new XmlSerializerNamespaces();
		}
		public override Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, HttpContent content, TransportContext transportContext)
		{
			var serializer = new XmlSerializer(type);
			var xmlWriter = new XmlTextWriter(writeStream, Encoding.UTF8)
			{
				Namespaces = true
			};
			serializer.Serialize(xmlWriter, value, Namespaces);
			return Task.FromResult(true);
		}
	}

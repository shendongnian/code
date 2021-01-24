	public class CustomXmlFormatter : XmlMediaTypeFormatter
	{
		public XmlSerializerNamespaces Namespaces { get; }
		private ConcurrentDictionary<Type, XmlSerializer> Serializers { get; }
		public CustomXmlFormatter()
		{
			Namespaces = new XmlSerializerNamespaces();
			Serializers = new ConcurrentDictionary<Type, XmlSerializer>();
		}
		public override Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, HttpContent content, TransportContext transportContext)
		{
			var serializer = Serializers.GetOrAdd(type, x => new XmlSerializer(type));
			var xmlWriter = new XmlTextWriter(writeStream, Encoding.UTF8)
			{
				Namespaces = true
			};
			serializer.Serialize(xmlWriter, value, Namespaces);
			return Task.FromResult(true);
		}
	}

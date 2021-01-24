	public static MSG DeserializeMyMsg(string xmlstr)
	{
		using (var reader = new StringReader(xmlstr))
		using (var xmlreader = XmlReader.Create(reader))
		using (var serializationReader = new StringReader(xmlstr))
		{
			var serializer = new XmlSerializer(typeof(MSG));
			var chosenSerializer = serializer.CanDeserialize(xmlreader)
				? serializer 
				: new XmlSerializer(typeof(MSGLegacyWrapper));
			return chosenSerializer.Deserialize(serializationReader) as MSG;
		}
	}

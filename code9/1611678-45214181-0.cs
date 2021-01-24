	public static TObject XmlDeserialize<TObject>(XDocument xmlToDeserialize) 
	{
		TObject deserializedObject = default(TObject);
		XmlSerializer serializer = new XmlSerializer(typeof(TObject));
		using (System.IO.TextReader reader = new System.IO.StringReader(xmlToDeserialize.ToString()))
		{
			deserializedObject = (TObject)serializer.Deserialize(reader);
		}
		
		return deserializedObject;
	}

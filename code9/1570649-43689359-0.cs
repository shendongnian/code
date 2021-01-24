    public static T Deserialize<T>(XElement xElement)
    {
    	using (MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xElement.ToString()))) {
    		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
    		return (T)xmlSerializer.Deserialize(memoryStream);
    	}
    }
     GetCRResponse resp = Deserialize<GetCRResponse>(body);

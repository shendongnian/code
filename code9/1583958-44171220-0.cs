    Dictionary<string, dynamic> inputDict = new Dictionary<string, dynamic>();
    var xmlString = SerializeObject(inputDict);
    
    public static string SerializeObject<T>(this T toSerialize)
    {
    	XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
    
    	StringWriter textWriter = new StringWriter();
    
    	xmlSerializer.Serialize(textWriter, toSerialize);
    	return textWriter.ToString();
    }

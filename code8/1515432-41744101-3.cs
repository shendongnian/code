    public static class XmlDeserializerService<T>
    {
    	public static T LoadDataToClass(string filePath)
    	{    
    		XmlSerializer serializer = new XmlSerializer(typeof(T));
    		using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
    		{
    			return  (T)serializer.Deserialize(fileStream);
    		}
    	}
    }

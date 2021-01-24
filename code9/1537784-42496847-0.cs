    public static T DeserializeObject<T>(string inputString)
	{
		T result = default(T);
		using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(inputString)))
		{
			try
			{
				var serializer = new DataContractJsonSerializer(typeof(T));
				result = (T)serializer.ReadObject(ms);
				WriteLine($"\nDeserialization Success : { result }\n");
			}
			catch (Exception ex)
			{
				WriteLine($"\nDeserialization Failed With Exception : { ex }\n");
			}
		}
		return result;
    }	

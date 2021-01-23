    public static object Deserialize(Type objType, FileInfo xmlDocFile)
    {
        object returnValue = null;            
        if (xmlDocFile != null && objType != null && xmlDocFile.Exists)
        {
			DataContractSerializer formatter = new DataContractSerializer(objType);
			using (FileStream fs = File.Open(xmlDocFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				using (BufferedStream bs = new BufferedStream(fs))
				{
					XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(bs, Encoding.UTF8, new XmlDictionaryReaderQuotas(), null);
					returnValue = formatter.ReadObject(reader, true);
				}
			}
        }
        return returnValue;
    }

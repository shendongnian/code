    public static object Deserialize(Type objType, FileInfo xmlDocFile)
    {
        object returnValue = null;
        if (xmlDocFile != null && objType != null && xmlDocFile.Exists)
        {
            DataContractSerializer formatter = new DataContractSerializer(objType);
                
            using (FileStream textFile = new FileStream(xmlDocFile.FullName, FileMode.Open))
            {
                returnValue = formatter.ReadObject(textFile);
            }
        }
        return returnValue;
    }

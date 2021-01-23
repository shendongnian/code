    public String ConvertObjectToJSONString<myObjectType>(myObjectType myObject)
    {
        string content = String.Empty;
        var js = new DataContractJsonSerializer(typeof(myObjectType));
        var ms = new MemoryStream();
        js.WriteObject(ms, myObject);
        ms.Position = 0;
        var reader = new StreamReader(ms);
        content = reader.ReadToEnd();
        return content;
    }

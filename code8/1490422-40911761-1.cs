    private void WriteToConsole ()
    {
        var jsonReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(@"{ ""Security"": { ""UsernameToken"": { ""Username"": ""belljeantest"", ""Password"": ""r@b!e$"" } }"), new System.Xml.XmlDictionaryReaderQuotas());
        var xml = XDocument.Load(jsonReader);
        Console.Write(xml);
        Console.ReadLine();
    }

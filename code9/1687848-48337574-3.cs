    void DoSomething<T, U>(string xmlFileName) where U: IPlural<T> where T: new()
    {
        string xmlFilePath = pathFromserverFolder + "/" + xmlFileName;
        XmlSerializer deserializer = new XmlSerializer(typeof(T));
        TextReader textReader = new StreamReader(xmlFilePath);
        U u = (U)deserializer.Deserialize(textReader);
        textReader.Close();
        //connection to db
        connection.DeleteAll<T>();
        List<T> all = u.All;
        connection.InsertAll(all);
        int numArticlesImported = connection.Table<T>().ToList().Count;
    }
    interface IPlural<T>
    {
        List<T> All { get; set; }
    }

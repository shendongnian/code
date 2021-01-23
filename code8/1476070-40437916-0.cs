    class Parent<T>
    {
        public T child { get; set; }
    }
    class child
    {
         string attribute1 { get; set; }
         string attribute2 { get; set; }
         string attribute3 { get; set; }
    }
    var parentWithList = JsonConvert.DeserializeObject<Parent<List<string>>>(yourFirstJson);
    
    var parentWithSingleChild = JsonConvert.DeserializeObject<Parent<child>(yourSecondJson);

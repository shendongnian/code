    class MyTableUtilClass
    {
        public string Status{get;set;}
        public string Message {get;set;}
        public DataTable Table{get;set;}
    }
    var myUtil=JsonConvert.DeserializeObject<MyTableUtilClass>(jsonText);
    DataTable myTable=myUtil.Table;

        public class Datum
        {
            public object pKey { get; set; }
            public string Entity { get; set; }
            public string Attribute { get; set; }
            public string iValue { get; set; }
            public string sValue { get; set; }
        }
        public class DataCollection
        {
            public List<Datum> data { get; set; }
        }
        public void Test()
        {
            var str = "{\"data\":[{\"pKey\":\"0\",\"Entity\":\"tableName\",\"Attribute\":\"CID\",\"iValue\":\"13\"},{\"pKey\":\"0\",\"Entity\":\"tableName\",\"Attribute\":\"username\",\"sValue\":\"test_user1\"}]}";
            var list = JsonConvert.DeserializeObject<DataCollection>(str);
            var keys = list.data.Select(x => x.pKey).ToList();
        }

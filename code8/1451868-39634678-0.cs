     RootObject item = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(@"D:\file.txt"));
     public class RootObject
        {
            public List<string> val1 { get; set; }
            public int val2 { get; set; }
            public string val3 { get; set; }
            public object val4 { get; set; }
            public string valJSON { get; set; }
        }

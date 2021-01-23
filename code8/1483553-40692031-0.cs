            public class RootObject
        {
            public string character { get; set; }
            public string credit_id { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string profile_path { get; set; }
            public int order { get; set; }
        }
    
    
    var x =JsonConvert.DeserializeObject<List<RootObject>>(myjsondata);
    var character = x[index].character;

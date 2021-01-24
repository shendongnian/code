    class Test
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
-
    DateTime dtParse;
    
    var deserializeJson = (from d in JsonConvert.DeserializeObject<Test[]>(entity)
                           select new Test()
                           {
                                 Key = d.Key,
                                 Value = DateTime.TryParse(d.Value, out dtParse) == true ? Convert.ToDateTime(d.Value).ToString("yyyy-MM-ddTHH:mm:ss.fffffff") : d.Value
                           }).ToList();

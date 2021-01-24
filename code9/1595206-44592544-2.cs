    class Test
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
-
    var deserializeJson = (from d in JsonConvert.DeserializeObject<Test[]>(entity)
                           select new Test()
                           {
                                 Key = d.Key,
                                 Value = d.Key == "PendingDate" || d.Key == "CreatedDate" || d.Key == "ModifiedDate" ? Convert.ToDateTime(d.Value).ToString("yyyy-MM-ddTHH:mm:ss.fffffff") : d.Value
                           }).ToList();

    class Test
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
-
    var Deserializejson = JsonConvert.DeserializeObject<Test[]>(entity);
    var result = (from dd in Deserializejson
                  select new Test()
                  {
                        Key = dd.Key,
                        Value = dd.Key == "PendingDate" || dd.Key == "CreatedDate"  || dd.Key == "ModifiedDate" ? Convert.ToDateTime(dd.Value).ToString("yyyy-MM-ddTHH:mm:ss.fffffff") : dd.Value
                  }).ToList();

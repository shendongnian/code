    class Test
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
-
    var Deserializejson = JsonConvert.DeserializeObject<Test[]>(entity, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffffff" });
    var resultDate = (from dd in Deserializejson
                      where dd.Key == "PendingDate" || dd.Key == "CreatedDate" || dd.Key == "ModifiedDate"
                      select new Test()
                             {
                                 Key = dd.Key,
                                 Value = Convert.ToDateTime(dd.Value).ToString("yyyy-MM-ddTHH:mm:ss.fffffff")
                             }).ToList();
    var resultNoDate = (from dd in Deserializejson
                        where dd.Key == "OwnerId" || dd.Key == "ProductList"
                        select new Test()
                            {
                                     Key=dd.Key,
                                     Value=dd.Value
                            }).ToList();
    var finalresult = resultDate.Union(resultNoDate);

    var result = dt.AsEnumerable().GroupBy(x => x.Field<string>("Name"))
                   .Select(x => new
                           {
                               Name = x.Key,
                               Address = x.Where(z => z.Field<string>("Address") != null)
                                          .Select(z => z.Field<string>("Address")).ToList()
                           });
    
    string jsonResult = JsonConvert.SerializeObject(result);

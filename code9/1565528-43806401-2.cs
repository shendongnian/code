      var response = db.Search<Error>(s => 
                    s.Size(0)
                    .Aggregations(aggs1 => aggs1.Terms("level1",
                            l1 =>l1.Field(f => f.Type)
                                   .Aggregations(aggs2 => aggs2.Terms("leve2", t=> t.Field(f=>f.Year))))));
    
               foreach (var l1 in response.Aggs.Terms("level1").Buckets)
               {
                   foreach (var l2 in l1.Terms("leve2").Buckets)
                   {
                       Console.WriteLine("Type:{0}, Year:{1}, Count:{2}", l1.Key, l2.Key, l2.DocCount);
                   }
               }

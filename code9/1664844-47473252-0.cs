    var uri = new Uri("http://localhost.fiddler:9200");
    
                ElasticClient db = new ElasticClient(uri);
    
                var data = new[] {
                                    new{ BookName= "X", Author="a" },
                                    new{ BookName= "Y", Author="a" },
                                    new{ BookName= "Z", Author="b" },
                                    new{ BookName= "C", Author="b" },
                                    new{ BookName= "T", Author="c" },
                                };
    
                db.DeleteIndex("test");
    
                foreach (var d in data)
                {
                    db.Index(d, id => id.Index("test"));
                }
    
                System.Threading.Thread.Sleep(1000);
    
                var items = db.Search<dynamic>(s => s.Size(0).Aggregations(aggr => aggr.Terms("group_by_auth", ts => ts.Field("author.keyword"))));
    
                foreach (var item in items.Aggs.Terms("group_by_auth").Buckets)
                {
                    Console.WriteLine(item.Key + "-" + item.DocCount);
                }
    
                Console.WriteLine("DONE");
    
                Console.ReadLine();

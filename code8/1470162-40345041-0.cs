     class Program
        {
            static void Main(string[] args)
            {
                var random = new Random();
                var uri = new Uri("http://localhost.fiddler:9200");
                var indexName = "test_index";
    
                ElasticClient db = new ElasticClient(uri);
    
                db.DeleteIndex(indexName);
    
                foreach (var item in Enumerable.Range(0, 10).Select(i => new A { Price1 = random.NextDouble() * 1000 }))
                {
                    db.Index(item, inx => inx.Index(indexName));
                }
    
                foreach (var item in Enumerable.Range(0, 10).Select(i => new B { Price2 = random.NextDouble() * 1000 }))
                {
                    db.Index(item, inx => inx.Index(indexName));
                }
    
                //db.IndexMany(Enumerable.Range(0, 10).Select(i => new A { Price1 = random.NextDouble() * 1000 }), indexName); When using this got nothing back since the query was too fast after index
                //db.IndexMany(Enumerable.Range(0, 10).Select(i => new B { Price2 = random.NextDouble() * 1000 }), indexName);
    
                var data = db.Search<JObject>(q =>
                    q.Index(indexName)
                    .Size(20)
                    .Type("")
                    .Sort(s => s.Script(scd => scd
                        .Type("number")
                        .Script(sc => sc
                            //.Inline(@" doc['price1']?  doc['price1'] : doc['price2']") if no price1 field in object B then you can use this and no need for TypeIndex
                            .Inline(@"doc['typeIndex'] == 0?  doc['price1'] : doc['price2']")// typeIndex must be a number lucene has no string literal support
                            .Lang("expression")
                            ).Order(SortOrder.Descending))));
    
    
                Console.WriteLine("DONE");
    
                Console.ReadLine();
            }
        }
    
        [ElasticsearchType(Name="A")]
        public class A 
        {
            [Number]
            public int TypeIndex { get { return 0; } }
    
            [Number]
            public double Price1 { get; set; }
        }
    
        [ElasticsearchType(Name = "B")]
        public class B
        {
            [Number]
            public int TypeIndex { get { return 1; } }
    
            [Number]
            public double Price2 { get; set; }
        }

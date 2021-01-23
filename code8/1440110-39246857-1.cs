    static void Main(string[] args)
            {
                ElasticClient db = new ElasticClient(new Uri("http://localhost.fiddler:9200"));
    
                db.IndexMany(Enumerable.Range(0, 100).Select(i => new Data { Id = i, Name = "Name" + i }), "test_index");
    
                var mappings = db.GetMapping<Data>();
    
                var delete = db.DeleteIndex(new DeleteIndexRequest("test_index"));
    
                var indexMapping = mappings.IndexTypeMappings["test_index"].ToDictionary(k => k.Key, v => (ITypeMapping)v.Value);
    
                db.CreateIndex(new CreateIndexRequest("test_index")
                {
                    Mappings = new Mappings(indexMapping)
                });
    
                Console.ReadLine();
            }
    
            class Data 
            {
                public int Id { get; set; }
    
                public string Name { get; set; }
            }

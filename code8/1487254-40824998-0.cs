    class Program
        {
            static void Main(string[] args)
            {
                var url = new Uri("http://localhost.fiddler:9200");
                ElasticClient db = new ElasticClient(url);
                string[] lang = { "EN", "DE" };
    
                db.Map<A>(des => des.AutoMap()
                .Index("a")
                .Properties(
                    p => p.Object<JObject>(
                        f => f.Name(n => n.Name).Properties(
                            props => props.String(
                                fen => fen.Name(lang[0])).String(fde => fde.Name(lang[1]))))));
    
                foreach (var item in Enumerable.Range(0, 10).Select(i => new A
                {
                    PropA = i,
                    Name = new JObject
                    {
                        [lang[0]] = "ABC" + i,
                        [lang[1]] = "GABC"
                    }
                }))
                {
                    var a = db.Index<A>(item, i => i.Index("a"));
                }
    
    
                var items = db.Search<A>(s=>s.Query(q=>q.Match(m=>m.Field("name.EN").Query("ABC1"))));
    
                Console.ReadLine();
            }
        }
        
        class A
        {
            [Number]
            public int PropA { get; set; }
            
            public JObject Name { get; set; }
        }

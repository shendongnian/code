    public class EO_CategoryAutocomplete
    {
        public string Id { get; set; }
        public IEnumerable<string> L { get; set; }
        public CompletionField Suggest { get; set; }
    }
    
    void Main()
    {
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
        var connectionSettings = new ConnectionSettings(pool)
                .DefaultIndex("autocomplete");
    
        var client = new ElasticClient(connectionSettings);
    
        if (client.IndexExists("autocomplete").Exists)
            client.DeleteIndex("autocomplete");
    
        client.CreateIndex("autocomplete", ci => ci
            .Mappings(m => m
                .Map<EO_CategoryAutocomplete>(mm => mm
                    .AutoMap()
                    .Properties(p => p
                        .Completion(c => c
                            .Contexts(ctx => ctx
                                .Category(csug => csug
                                    .Name("lang")
                                    .Path("l")
                                )
                                .Category(csug => csug
                                    .Name("type")
                                    .Path("t")
                                )
                                .Category(csug => csug
                                    .Name("home")
                                    .Path("h")
                                )
                            )
                            .Name(n => n.Suggest)
                        )
                    )
                )
            )
        );
    
        client.IndexMany(new[] {
            new EO_CategoryAutocomplete 
            {
                Id = "1",
                Suggest = new CompletionField
                {
                    Input = new [] { "async", "await" },
                    // explicitly pass a context for lang
                    Contexts = new Dictionary<string, IEnumerable<string>>
                    {
                        { "lang", new [] { "c#" } }
                    }
                }
            },
            new EO_CategoryAutocomplete
            {
                Id = "2",
                Suggest = new CompletionField
                {
                    Input = new [] { "async", "await" },
                    // explicitly pass a context for lang
                    Contexts = new Dictionary<string, IEnumerable<string>>
                    {
                        { "lang", new [] { "javascript" } }
                    }
                }
            },
            new EO_CategoryAutocomplete
            {
                Id = "3",
                // let completion field mapping extract lang from the path l
                L = new [] { "typescript" },
                Suggest = new CompletionField
                {
                    Input = new [] { "async", "await" },
                }
            }
        }, "autocomplete");
        
        client.Refresh("autocomplete");
        
        var searchResponse = client.Search<EO_CategoryAutocomplete>(s => s
            .Suggest(su => su
                .Completion("categories", cs => cs
                    .Field(f => f.Suggest)
                    .Prefix("as")
                    .Contexts(co => co
                        .Context("lang", 
                            cd => cd.Context("c#"), 
                            cd => cd.Context("typescript"))
                    )
                )
            )
        );
    
        // do something with suggestions
        var categorySuggestions = searchResponse.Suggest["categories"];
    }

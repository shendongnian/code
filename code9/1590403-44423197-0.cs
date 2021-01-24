    void Main()
    {
    	var client = new ElasticClient();
        var listOfContextValues = new List<string> { "10", "20", "30" }; 
        var query = "query";
        
        var searchResponse = client.Search<Post>(s => s
                    .Suggest(su => su
                        .Completion("categories", cs => cs
                            .Field(f => f.CSuggest)
                            .Prefix(query)
                            .Contexts(co => co
                                .Context("sourceid",
                                    listOfContextValues
                                        .Select<string, Func<SuggestContextQueryDescriptor<Post>, ISuggestContextQuery>>(v => cd => cd.Context(v))
                                        .ToArray()
                                )
                            )
                        )
                    )
                );
    }
    
    public class Post
    {
    	public CompletionField CSuggest { get; set; }
    }

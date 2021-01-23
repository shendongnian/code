    public class Document
    {
        public string Property1 { get; set; }
    }
    var searchResponse = client.Search<Document>(s => s
        .Query(q => q
            .MatchPhrasePrefix(p => p
                .Field(f => f.Property1)
                .Query("Prefix phrase")
            )
        )
    ); 

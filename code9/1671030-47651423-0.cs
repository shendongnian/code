    public class LemmagenTokenFilter : ITokenFilter
    {
        public string Version { get; set; }
        public string Type => "lemmagen";
        [JsonProperty("lexicon")]
        public string Lexicon { get; set; }
    }
    
    
    var response = elasticClient.CreateIndex(_defaultIndex,
        d => d.Settings(s => s
            .Analysis(a => a
                .TokenFilters(t => t.UserDefined("lemmagen_filter_sk",
                    new LemmagenTokenFilter
                    {
                        Lexicon = "sk"
                    }))))
    				..
    				);

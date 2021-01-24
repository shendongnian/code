    private static void CreateHotelsIndex(ISearchServiceClient serviceClient)
    {
        var definition = new Index
        {
            Name = "hotels",
            Fields = FieldBuilder.BuildForType<Hotel>(),
            Analyzers = new[]
            {
                new CustomAnalyzer
                {
                    Name = "my_analyzer",
                    Tokenizer = TokenizerName.Standard,
                    TokenFilters = new[]
                    {
                        TokenFilterName.Lowercase,
                        TokenFilterName.AsciiFolding,
                        TokenFilterName.Phonetic
                    }
                }
            }
        };
        serviceClient.Indexes.Create(definition);
    }

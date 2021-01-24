    customAnalyzer.Tokenizer = "mynGram";
                customAnalyzer.Filter = new List<string> { "lowercase" };
    
                indexSettings.Analysis.Analyzers.Add("mynGram", customAnalyzer);
                indexSettings.Analysis.Tokenizers.Add("mynGram",
                                                      new NGramTokenizer
                                                      {
                                                          MaxGram = 10,
                                                          MinGram = 2
                                                      });

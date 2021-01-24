    using System.Speech.Recognition;
    ...
    private DictationGrammar dictationGrammar;
    private Grammar placeholderGrammar;
    private List<Grammar> commands;
    public void Initialize()
    {
        dictationGrammar = new DictationGrammar();
        recognizer.LoadGrammarAsync(dictationGrammar);
        var builder = new GrammarBuilder();
        builder.Append("MYPLACEHOLDER");        
        placeholderGrammar = new Grammar(builder);
        recognizer.LoadGrammarAsync(placeholderGrammar);
        commands = new List<Grammar>();
        foreach (var grammar in grammarManager.GetGrammars())
        {
            commands.Add(grammar);           
            grammar.Enabled = false;
            recognizer.LoadGrammarAsync(grammar);
        }
    }

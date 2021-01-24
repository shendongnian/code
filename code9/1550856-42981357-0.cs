    FileHelperEngine engine = new FileHelperEngine<Transaction>(); 
    engine.BeforeReadRecord += BeforeEvent; 
    
    private void BeforeEvent(EngineBase engine, BeforeReadRecordEventArgs e)
    {
        var line = e.RecordLine;
        // you have to write the following replacement routine...
        var fixedLine = ReplaceEmbeddedCommasAndQuotesWithSomethingDifferent(line); 
        
        e.RecordLine = fixedLine; // replace the line with the fixed version
    }

    List<Action> LogActions = new List<Action>();
    Action WriteAction;
    
    
    // Create Multiple Actions 
    WriteAction = () =>
    {
        paragraph.Inlines.Add(new LineBreak());
        paragraph.Inlines.Add(new Bold(new Run("Example")) { Foreground = Brushes.White });
    };
    // Add Actions to List
    LogActions.Add(WriteAction);
    
    
    // At End of Program or in a Method:
    
    public void LogWriteAll() {
    	// Write All Actions in List
    	myWindow.rtbLog.Document = new FlowDocument(paragraph);
    
    	// Begin Rich Textbox Change
    	myWindow.rtbLog.BeginChange();
    
    	foreach (Action Write in LogActions)
    	{
    	    Write();
    	}
    
    	myWindow.rtbLog.EndChange();
    }

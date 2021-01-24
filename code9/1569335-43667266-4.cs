    public DebuggerAction GetAction(int ip, SourceRef sourceref)
    {
    	if( _abortScript )			
           throw new MyException();  // abort cleanly
        
        // Proceed running the next statement
    	return new DebuggerAction() { 
          Action = DebuggerAction.ActionType.StepIn,
        };
    }

    //Try this
    public void LogReturnValue(obj returnValue)
    {
       var valueToLog = "";
       if(returnValue is Task)
       {
           valueToLog = returnValue;
       } 
       else
       {
         valueToLog = returnValue.Result;
       }   
       this.logger.Log(valueToLog);
    }
    
    //OR this
    
    public void LogReturnValue(obj returnValue)
    {
       var valueToLog = "";
       if( returnValue.GetType() == typeof(Task))
       {
           valueToLog = returnValue;
       } 
       else
       {
         valueToLog = returnValue.Result;
       }   
       this.logger.Log(valueToLog);
    }

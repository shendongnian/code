       try
      {
        ...code above
               if (SendMail(sSubject, sBody))
                    {
                       Dts.TaskResult = (int)ScriptResults.Success;
                    }
               else
                    {
                        Dts.TaskResult = (int)ScriptResults.Failure;
                    }
              //Remove this, because it overwrites the actions from above
              //Dts.TaskResult = (int)ScriptResults.Success;
       }
    
      catch (Exception e)
      {
            //error handling                
      }

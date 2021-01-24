    public class SomethingSpecificWentWrongException: Exception
    {
       public int SessionId  {get;protected set;}
       public SomethingSpecificWentWrongException(int sessionId): 
         base($"Something specific went horribly wrong with session {sessionId}")
       {
         SessionId=sessionId;
       }
    }

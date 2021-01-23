    public class Event {
      public int Id {get;set;}
    }
    public class Participant{
      public int Id {get;set;}
    }
    public class NewTable{
       public int Id {get;set;}
       public int EventId  {get;set;}
       public int PaticipantId {get;set;}
    }
    public class Registration{
      public int Id {get;set;}
      public int NewTableId {get;set;}
    }

    public class FirstClass : IUpdateAction {
    
      public Action Update {get; set;}
      [UpdateAction]
      public string Description {get;set;}
    
    }

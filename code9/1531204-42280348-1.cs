    internal interface ITInput {
       string SomeThing { get; set; }
    }
    
    internal interface ITOutput {
       Guid SomeGuid { get; set; }
    }
    
    internal class AnotherInput : ITInput {
       public string SomeThing { get; set; }
    }
    
    internal class SomeInput : ITInput {
       public string SomeThing { get; set; }
    }
    
    internal class SomeOutput : ITOutput {
       public Guid SomeGuid { get; set; }
    }
    
    internal class SomeOtherOutput : ITOutput {
       public Guid SomeGuid { get; set; }
    }
   

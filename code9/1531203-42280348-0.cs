    class Mangler<TInput, TOutput> 
       where TInput: ITInput 
       where TOutput: ITOutput {
    
       public TInput Input { get; set; }
       public TOutput Output { get; set; }
       public bool IsInputAGuid() {
          if (Guid.Parse(this.Input.SomeThing) == this.Output.SomeGuid ) {
             return true;
          }
    
          return false;
       }
    }

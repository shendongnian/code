    public interface IBackendDataConnector
    {
        public Task<Something> DoSomethingAsync(Settings settings);
        public bool CanHandleEnvironment(EnvironmentType environment);
    }
    
    public abstract class DataHandlerAbstractBase: IBackendDataConnector
    {
       protected abstract EnvironmentType Environment { get; }
      
       // interface API
       public abstract async Task<Something> DoSomethingAsync(Settings settings);
    
       public virtual bool CanHandleEnvironment(EnvironmentType environment)
       {
           return environment == Environment;
       }
    }
    
    public class DataHandlerClass: DataHandlerAbstractBase
    {
       protected override EnvironmentType Environment 
       {
         get { return EnvironmentType.ExampleA; }
       }
    
       public override async Task<Something> DoSomethingAsync(Settings settings)
       {
         // implementation goes here
       }
    }
    

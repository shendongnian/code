    public class ExampleClass
    {
         private IRegistryActions registryActions;
         public ExampleClass(IRegistryActions registryActions)
         {
              this.registryActions = registryActions;
         }
         public bool WriteValue(string key, string value)
         {
              return registryActions.WriteValue(key, value);
         }
    }

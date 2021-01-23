     public class ExternalDataFactory
     {
        private readonly IEnumerable<IBackendDataConnector> _dataConnectors =
              new [] {new DataHandlerClass() /* other implementations */}
                      
        public IBackendDataConnector CreateDataHandler(Settings setting)
        {                
           IBackendDataConnector connector = _dataConnectors
    .FirstOrDefault(
         c => c.CanHandleEnvironment(setting.EnvironmentType));
    
           if (connector == null)
           {
               throw new ArgumentException("Unsupported environment type");
           }
    
           return connector;
        }
     }

    public class Dispatcher : IDispatcher {
        private readonly IServiceProvider serviceProvider;
    
        public Dispatcher (IServiceProvider serviceProvider) {
            this.serviceProvider = serviceProvider;
        }
    
        //...other code removed for brevity
        private object GetService(Type serviceType) {
            return serviceProvider.GetService(serviceType);
        }
        private void ExecuteHandler(Type handlerType, object argument, Type argumentType) {
            object handler = GetService(handlerType);
    
            if (handler == null)
                throw new ConfigurationErrorsException("Handler not registered for type " + argumentType.Name);
    
            try {
                MethodInfo handleMethod = handlerType.GetMethod(HandleMethodName, new[] { argumentType });
                handleMethod.Invoke(handler, new[] { argument });
            } catch (TargetInvocationException ex) {
                if (ex.InnerException != null)
                    throw ex.InnerException;
                throw;
            }
        }
    
        private TReturnValue ExecuteHandler<TReturnValue>(Type handlerType, object argument, Type argumentType) {
            object handler = GetService(handlerType);
    
            if (handler == null)
                throw new ConfigurationErrorsException("Handler not registered for type " + argumentType.Name);
    
            try {
                MethodInfo handleMethod = handlerType.GetMethod(HandleMethodName, new[] { argumentType });
                return (TReturnValue)handleMethod.Invoke(handler, new[] { argument });
            } catch (TargetInvocationException ex) {
                if (ex.InnerException != null)
                    throw ex.InnerException;
                throw;
            }
        }    
    }

    public class ServiceFactory : Dictionary<string, Type>
    {
        public void Register(string typeName, Type serviceType) {
            if (this.ContainsKey(typeName)) {
                throw new Exception("Type registered");
            }
            this[typeName] = serviceType;
        }
    
        public IRequest Resolve(string typeName) {
            if (!this.ContainsKey(typeName)) {
                throw new Exception("Type not registered");
            }
            var type = this[typeName];
            var service = Activator.CreateInstance(type);
            return service as IRequest;
        }
    }

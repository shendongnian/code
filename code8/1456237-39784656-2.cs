    public class CacheManagerConstructorResolutionBehavior 
        : IConstructorResolutionBehavior {
        private readonly IConstructorResolutionBehavior org;
        public CacheManagerConstructorResolutionBehavior(IConstructorResolutionBehavior org) {
            this.org = org;
        }
        public ConstructorInfo GetConstructor(Type serviceType, Type implementationType) {
            if (implementationType.IsGenericType && 
                implementationType.GetGenericTypeDefinition() == typeof(BaseCacheManager<>)) {
                return implementationType.GetConstructors()
                    .OrderByDescending(c => c.GetParameters().Length)
                    .First();
            }
            return this.org.GetConstructor(serviceType, implementationType);
        }
    }
    
    var container = new Container();
    container.Options.ConstructorResolutionBehavior =
        new CacheManagerConstructorResolutionBehavior(
            container.Options.ConstructorResolutionBehavior);

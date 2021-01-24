    public class UmbracoConstructorBehavior : IConstructorResolutionBehavior
    {
        public IConstructorResolutionBehavior DefaultBehavior { get; set; }
        public ConstructorInfo GetConstructor(Type implementationType)
        {
            return implementationType.Namespace != null 
              && implementationType.Namespace.Contains("Umbraco")
                ? GetUmbracoConstructor(implementationType)
                : DefaultBehavior.GetConstructor(implementationType);
        }
 
        private ConstructorInfo GetUmbracoConstructor(Type i) => 
           i.GetConstructors().OrderBy(c => c.GetParameters().Length).FirstOrDefault() 
           ?? DefaultBehavior.GetConstructor(i);
    }

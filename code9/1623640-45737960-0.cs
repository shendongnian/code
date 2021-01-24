    public ServiceBase()
    {
        IEnumerable<PropertyInfo> dependencyProperties;
        var dependencyAttribute = typeof(Microsoft.Practices.Unity.DependencyAttribute);
        
        // DependencyService.Get<> requires a type parameter so we have to call it by using reflection
        var dependencyServiceGet = typeof(DependencyService).GetRuntimeMethod("Get", new Type[] { typeof(DependencyFetchTarget) });
        
        // Get the properties from our derrived type (accessed by using "this")
        dependencyProperties = this.GetType().GetTypeInfo().DeclaredProperties;
        //Check if any properties have been tagged with the DependencyAttribute
        dependencyProperties = dependencyProperties.Where(x =>
        {
            return x.CustomAttributes.Any(y => y.AttributeType == dependencyAttribute);
        });
        foreach (var prop in dependencyProperties)
        {
            // Add the type parameter to the Get-method
            var resolve = dependencyServiceGet.MakeGenericMethod(prop.PropertyType);
            // Now resolve the property via reflection: DependencyService.Get<PropertyType>();
            var service = resolve.Invoke(null, new object[] { DependencyFetchTarget.GlobalInstance });
            if (service == null)
                throw new InvalidOperationException($"Herke.Forms.Core.ServiceBase: Dependency could not be resolved, did you forget to register?{Environment.NewLine}Type: {prop.PropertyType.FullName}{Environment.NewLine}Suggested code: \"[assembly: Dependency(typeof( >ImplementatingClass< ))]\"");
            // Fill property value
            prop.SetValue(this, service);
        }
    }
    
    [assembly: Xamarin.Forms.Dependency(typeof(Bar))]    
    public class Bar : IBar
    { }
	
    [assembly: Xamarin.Forms.Dependency(typeof(Foo))]
    public class Foo : ServiceBase, IFoo
    {
		[Microsoft.Practices.Unity.Dependency]
        public IBar Bar { get; set; }
        
        // Foo can use Bar now !
    }

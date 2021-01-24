     public class HomeController : Controller
     {
            private readonly Dictionary<string, IAuthenticationProvider> authProvidersDictionary;
    
            public HomeController(IAuthenticationResolver resolver)
            {
                System.Reflection.Assembly ass = System.Reflection.Assembly.GetEntryAssembly();
                this.authProvidersDictionary = new Dictionary<string, IAuthenticationProvider>();
    
                foreach (System.Reflection.TypeInfo ti in ass.DefinedTypes)
                {
                    if (ti.ImplementedInterfaces.Contains(typeof(IAuthenticationProvider)))
                    {                   
                        
                        this.authProvidersDictionary.Add(ti.Name, resolver.GetProvider(ti.UnderlyingSystemType));
                    }
                }            
            }
    }

    public class GlimpseSecurityPolicy : IRuntimePolicy
        {
            public RuntimeEvent ExecuteOn => RuntimeEvent.EndRequest | RuntimeEvent.ExecuteResource;
    
            public RuntimePolicy Execute(IRuntimePolicyContext policyContext)
            {
                var aclManager = DependencyResolver.Current.GetService<IAclManager>();
                var userSession = DependencyResolver.Current.GetService<IUserSession>();
    
                if (!aclManager.IsUserAllowed(UserAction.AccessGlimpse, userSession.GetUser()))
                {
                    return RuntimePolicy.Off;
                }
    
                return RuntimePolicy.On;
            }
        }

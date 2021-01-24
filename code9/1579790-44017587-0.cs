    // Can be part of your Composition Root
    internal sealed class SecurityContextWrapper : ISecurityContext
    {
        // One of the rare cases that Property Injection makes sense.
        public ISecurityContext WrappedSecurityContext { get; set; }
        
        // Implement ISecurityContext methods here that delegate to WrappedSecurityContext.
    }
    // Composition Root. Only have 1 container for the complete application
    c = new Container();
    RegisterDependencies(c);
    c.Register<SecurityContextWrapper>(Lifestyle.Scoped);
    c.Register<ISecurityContext, SecurityContextWrapper>(Lifestyle.Scoped);
    // Job logic
    private readonly Container _container;
    internal async Task RunJob(BackgroundJob job) {
        var parameters = job.GetParameters();
        var securityContext = parameters.SecurityContext;
        using (AsyncScopedLifestyle.BeginScope(_container)) {
            // Resolve the wapper inside the scope
            var wrapper = _container.GetInstance<SecurityContextWrapper>();
            // Set it's wrapped value.
            wrapper.WrappedSecurityContext = securityContext;
        
            // Run the job within this scope.
        }
    }

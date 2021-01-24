    // Can be part of your Composition Root
    internal sealed class SecurityContextWrapper : ISecurityContext
    {
		ISecurityContext _wrappedSecurityContext;
	
		public SecurityContextWrapper(Scope scope)
		{
			_wrappedSecurityContext= (ISecurityContext)scope.GetItem(typeof(ISecurityContext));
		}
		
        // Implement ISecurityContext methods here that delegate to WrappedSecurityContext.
    }
    // Composition Root. Only have 1 container for the complete application
    c = new Container();
    RegisterDependencies(c);
    c.Register<ISecurityContext, SecurityContextWrapper>(Lifestyle.Scoped);
    // Job logic
    private readonly Container _container;
    internal async Task RunJob(BackgroundJob job) {
        var parameters = job.GetParameters();
        var securityContext = parameters.SecurityContext;
        using (var scope = AsyncScopedLifestyle.BeginScope(_container)) {
            // Set it's wrapped value.
            scope.SetItem(typeof(ISecurityContext), securityContext);
        
            // Run the job within this scope.
        }
    }

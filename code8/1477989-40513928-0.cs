    protected override void Execute(CodeActivityContext context)
    {
        var workflowContext = context.GetExtension<IWorkflowContext>();
        var event = workflowContext.MessageName;            
    }
    public void Execute(IServiceProvider serviceProvider)	
    {
        var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
        var event = context.MessageName;            
    }	

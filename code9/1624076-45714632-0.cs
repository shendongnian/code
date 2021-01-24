    var args = new ExplicitArguments();
    args.Set<Assembly>(Assembly.GetExecutingAssembly());
    
    var container = IoC.Initialize();
    var workflowProvider = container.GetInstance<WorkflowProvider>(args);

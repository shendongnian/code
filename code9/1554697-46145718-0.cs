    // Configure the event output to save logs as files
    Audit.Core.Configuration.Setup().UseFileLogProvider(_ => _.Directory(@"D:\Temp"));   
    
    // Add a custom action to filter out the events
    Audit.Core.Configuration.AddCustomAction(ActionType.OnScopeCreated, scope =>
    {
        var ef = scope.Event.GetEntityFrameworkEvent();
        var interested = ef.Entries.Any(e => e.Table == "Posts" 
                                        && new[] { "Insert", "Update" }.Contains(e.Action)
                                        && e.ColumnValues["Date"] == null);
        // Discard the audit event if we are not interested in (i.e. only log when Date is null)
        if (!interested)
        {
            scope.Discard();
        }
    });
    
    // Configure EF extension
    Audit.EntityFramework.Configuration.Setup() 
        .ForContext<YourContext>()      // Your context class type
            .UseOptIn()                 // OptIn to include specific entities 
            .Include<Post>();           // Audit only the Post entity

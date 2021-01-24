    var container = new Container(_ =>
    {
        _.Scan(x =>
        {
            x.TheCallingAssembly();
            x.WithDefaultConventions();
            x.AddAllTypesOf<IUpdateAction>();
        });
    });
    var actions = container.GetAllInstances<IUpdateAction>();
    foreach (IUpdateAction action in actions)
    {
        action.Execute(updatedItem);
    }

    public async Task<Obj1<XXXX>> DoSomething(string actionName, ....params....)
    {
        Type t = providedActions.Find(x => x.Name == actionName);
        if (t != null)
        {
            var action = (BaseAction)Activator.CreateInstance(t);
            return await action.Go(....params....);
        }
        else
            return null;
    } 

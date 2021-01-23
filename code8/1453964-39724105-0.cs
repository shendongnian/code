    /// <summary>
    /// Allows Plugin to trigger itself.  Delete Messge Types always return False 
    /// since you can't delete something twice, all other message types return true 
    /// if the execution key is found in the shared parameters.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    protected virtual bool PreventRecursiveCall(IExtendedPluginContext context)
    {
        if (context.Event.Message == MessageType.Delete)
        {
            return false;
        }
    
        var sharedVariables = context.SharedVariables;
        var key = $"{context.PluginTypeName}|{context.Event.MessageName}|{context.Event.Stage}|{context.PrimaryEntityId}";
        if (context.GetFirstSharedVariable<int>(key) > 0)
        {
            return true;
        }
    
        sharedVariables.Add(key, 1);
        return false;
    }

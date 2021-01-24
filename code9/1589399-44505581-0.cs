    public override void PreBuildUp(IBuilderContext context)
    {
    	var type = context.OriginalBuildKey.Type;
    
    	if (autoMoqContainer.Registrations.Any(r => r.RegisteredType == type))
    			return;
    
    	if (type.IsInterface || type.IsAbstract)
    	{
    		context.Existing = GetOrCreateMock(type);
    		context.BuildComplete = true;
    	}
    }

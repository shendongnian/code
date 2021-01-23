	// getting command
	var obj = _scope.ResolveNamed<ICommandDtc>(addFormDtc.SiteCollectionName);
	
	.....
	
	// consrtuction type which needded - ICommandBus<IntegerationCommand>
	var type = typeof(ICommandBus<>);
	var busType = type.MakeGenericType(obj.GetType());	
	
	// resolving needede type
	var commandBus = _scope.Resolve(busType);
	return commandBus.Submit(obj);

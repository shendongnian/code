	services.AddMvc(opts =>
	{
		opts.ModelBinderProviders.Insert(0, new AbstractModelBinderProvider<ActionViewModel>());
		opts.ModelBinderProviders.Insert(0, new AbstractModelBinderProvider<TriggerViewModel>());
	});

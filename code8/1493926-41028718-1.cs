	Type[] viewModels = AppDomain.CurrentDomain.GetAssemblies()
		.SelectMany(assembly => assembly.GetTypes())
		.Where(type => typeof(ViewModelBase).IsAssignableFrom(type) && type != typeof(ViewModelBase))
		.ToArray();
	MethodInfo registerMethod = typeof(SimpleIoc)
		.GetMethods()
		.Where(method => method.Name == nameof(SimpleIoc.Default.Register) && method.GetParameters().Length == 0 && method.GetGenericArguments().Length == 1)
		.First();
	foreach (Type viewModel in viewModels)
	{
		registerMethod
			.MakeGenericMethod(viewModel)
			.Invoke(SimpleIoc.Default, new object[0]);

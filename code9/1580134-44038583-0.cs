	container.RegisterType<IQueryHandler<TQuery, TResult>, QueryHandlerVersionOne<TQuery, TResult>>("1");
	container.RegisterType<IQueryHandler<TQuery, TResult>, QueryHandlerVersionTwo<TQuery, TResult>>("2");
	container.RegisterType<Func<int, IQueryHandler<TQuery, TResult>>>(
		new InjectionFactory(c =>
			new Func<int, IQueryHandler<TQuery, TResult>>((clientID) =>
			{
				var handler = c.Resolve<IQueryHandler<TQuery, TResult>>(clientID.ToString());
				return handler;
			})));

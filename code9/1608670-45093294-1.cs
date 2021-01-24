    internal Connection GetConnectionCore(string connectionName)
	{
		IList<string> signals = (connectionName == null) ? ListHelper<string>.Empty : new string[]
		{
			connectionName
		};
		string connectionId = Guid.NewGuid().ToString();
		return new Connection(this._resolver.Resolve<IMessageBus>(), this._resolver.Resolve<IJsonSerializer>(), connectionName, connectionId, signals, ListHelper<string>.Empty, this._resolver.Resolve<ITraceManager>(), this._resolver.Resolve<IAckHandler>(), this._resolver.Resolve<IPerformanceCounterManager>(), this._resolver.Resolve<IProtectedData>());
	}

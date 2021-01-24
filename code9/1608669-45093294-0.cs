    public IPersistentConnectionContext GetConnection(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		string fullName = type.FullName;
		string persistentConnectionName = PrefixHelper.GetPersistentConnectionName(fullName);
		IConnection connectionCore = this.GetConnectionCore(persistentConnectionName);
		return new PersistentConnectionContext(connectionCore, new GroupManager(connectionCore, PrefixHelper.GetPersistentConnectionGroupName(fullName)));
	}

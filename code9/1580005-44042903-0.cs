    object IDataContractSurrogate.GetDeserializedObject(object obj, Type targetType)
    {
    	bool supportIndividualAssemblies = this._proxyTypesAssembly != null;
    	OrganizationResponse organizationResponse = obj as OrganizationResponse;
    	if (organizationResponse != null)
    	{
    		Type typeForName = KnownProxyTypesProvider.GetInstance(supportIndividualAssemblies).GetTypeForName(organizationResponse.ResponseName, this._proxyTypesAssembly);
    		if (typeForName == null)
    		{
    			return obj;
    		}
    		OrganizationResponse organizationResponse2 = (OrganizationResponse)Activator.CreateInstance(typeForName);
    		organizationResponse2.ResponseName = organizationResponse.ResponseName;
    		organizationResponse2.Results = organizationResponse.Results;
    		return organizationResponse2;
    	}
    	else
    	{
    		Entity entity = obj as Entity;
    		if (entity == null)
    		{
    			return obj;
    		}
    		Type typeForName2 = KnownProxyTypesProvider.GetInstance(supportIndividualAssemblies).GetTypeForName(entity.LogicalName, this._proxyTypesAssembly);
    		if (typeForName2 == null)
    		{
    			return obj;
    		}
    		Entity entity2 = (Entity)Activator.CreateInstance(typeForName2);
    		entity.ShallowCopyTo(entity2);
    		return entity2;
    	}
    }

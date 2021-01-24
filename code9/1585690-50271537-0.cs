    VimClient vimClient = new VimClient();
    vimClient.Connect(host, CommunicationProtocol.Https, 443);
    vimClient.Login(userName, password);
    string token = string.Empty;
    
    while (true)
    {
        // Construct the property collector
        PropertyCollector propertyCollector = new PropertyCollector(vimClient, vimClient.ServiceContent.PropertyCollector);
        
        // Retrieve a batch of objects
        RetrieveResult result;
        if (!string.IsNullOrWhiteSpace(token))
             result = propertyCollector.ContinueRetrievePropertiesEx(token);
        else
        {
            result = propertyCollector.RetrievePropertiesEx(new[]
            {
                EntityViewBase.GetSearchFilterSpec(vimClient, vimClient.ServiceContent.RootFolder, new PropertySpec
                {
                    All = false,
                    Type = typeof(VirtualMachine),
                    PathSet = null
                })
            }, new RetrieveOptions { MaxObjects = 100 });
        }
    
        // Exit early if no entities retrieved
        if (null == result || 0 == result.Objects.Length)
            break;
    
        // Get the MoRefs of retrieval result
        List<ManagedObjectReference> objectMoRefList = result.Objects.Select(o => o.Obj).ToList();
    
        // Retrieve the properties of objects
        List <EntityViewBase> entityList = vimClient.GetViewsByMorefs(objectMoRefList)?.Select(viewBase => viewBase as EntityViewBase).ToList();
    
        // Return the objects and batch retrieval token
        token = new BatchRetrievalToken(result.Token)
        entityList.ForEach(e => yield return e);
    }

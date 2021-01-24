    [HttpGet("{id:int}")]
    public async Task<srting> Get(int id)
    {
    	var fabricClient = new FabricClient();
    	string applicationTypeName = "ApplicationTypeName";
    	string applicationVersion = "1.0.0";
    	string actorServiceManifestName = "Actor1Pkg";
    	var appManifest = await fabricClient.ServiceManager.GetServiceManifestAsync(applicationTypeName, applicationVersion, actorServiceManifestName);
    
    	var document = XDocument.Parse(appManifest);
        ...
        // TODO: Get DefaultService Name attribute from simple XML
    }

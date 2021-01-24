    var registry = new WebApiRegistry();
    var container = new Container(registry);
    //Register StructureMap with GlobalConfiguration
    GlobalConfiguration.Configuration.UseStructureMap(container);
    var endpointConfiguration = new EndpointConfiguration("My.WebApi.Sender");
    //...other code removed for brevity
    //Configuring NServiceBus to use the container
    endpointConfiguration.UseContainer<StructureMapBuilder>(
        customizations: customizations => {
            customizations.ExistingContainer(container);
        });
    //...other code removed for brevity
    
    var endpointInstance = await Endpoint.Start(endpointConfiguration);
    IMessageSession messageSession = endpointInstance as IMessageSession;
    // Now, change the container configuration to know how to use IMessageSession
    container.Configure(x => x.For<IMessageSession>().Use(messageSession));

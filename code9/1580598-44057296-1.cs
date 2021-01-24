    busConfiguration.AssembliesToScan(AllAssemblies
        .Matching("NServiceBus")
        .And("ServiceControl")
        .And(pingHandlerType.Assembly.GetName().Name)
        .And(pingEventType.Assembly.GetName().Name));

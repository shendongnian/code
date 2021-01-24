    busConfiguration.AssembliesToScan(AllAssemblies
        .Matching("NServiceBus")
        .And("ServiceControl")
        .And(pingHandlerType.AssemblyQualifiedName)
        .And(pingEventType.AssemblyQualifiedName));

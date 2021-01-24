    private static EntityMetadata RetrieveEntity(string entityName, IOrganizationService service)
    {
        var request = new RetrieveEntityRequest
        {
            LogicalName = entityName,
            EntityFilters = EntityFilters.All
        };
        return ((RetrieveEntityResponse)service.Execute(request)).EntityMetadata;
    }
    private static void AddEntityComponent(Guid componentId, int componentType, string solutionName, IOrganizationService service)
    {
        var request = new AddSolutionComponentRequest
        {
            AddRequiredComponents = false,
            ComponentId = componentId,
            ComponentType = componentType,
            DoNotIncludeSubcomponents = true,
            SolutionUniqueName = solutionName
        };
        service.Execute(request);
    }
    IOrganizationService service = factory.CreateOrganizationService(null);
    EntityMetadata entity = RetrieveEntity("account", service);
    AddEntityComponent(entity.MetadataId.Value, 1, "Test", service);
    AddEntityComponent(entity.Attributes.First(a => a.LogicalName == "accountnumber").MetadataId.Value, 2, "Test", service);

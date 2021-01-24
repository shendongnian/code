    // Create a schema extension for groups.
    SchemaExtension extensionDefinition = new SchemaExtension()
    {
        Description = "This extension correlates a group with a foreign database.",
        Id = $"crmForeignKey", // Microsoft Graph will prepend 8 chars
        Properties = new List<ExtensionSchemaProperty>()
        {
            new ExtensionSchemaProperty() { Name = "fid", Type = "Integer" }
        },
        TargetTypes = new List<string>()
        {
            "Group"
        }
    };
    
    // Create the schema extension. This results in a call to Microsoft Graph.
    SchemaExtension schemaExtension = await graphClient.SchemaExtensions.Request().AddAsync(extensionDefinition);

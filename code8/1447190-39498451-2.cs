    var context = new DirectoryContext(DirectoryContextType.Forest, "amber.local");
    using (var schema = System.DirectoryServices.ActiveDirectory.ActiveDirectorySchema.GetSchema(context))
    {
        var userClass = schema.FindClass("user");
        foreach (ActiveDirectorySchemaProperty property in userClass.GetAllProperties())
        {
            // property.Name is what you're looking for
        }
    }

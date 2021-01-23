        Name = "tomcustomindex",
        Fields = FieldBuilder.BuildForType<TomTestModel>()
    };
    //create Index
    if (serviceClient.Indexes.Exists(definition.Name))
    {
        serviceClient.Indexes.Delete(definition.Name);
    }
    var index = serviceClient.Indexes.Create(definition);`

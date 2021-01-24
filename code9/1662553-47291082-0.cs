    DesignerSerializationManager manager = new DesignerSerializationManager();
    using (var session = manager.CreateSession())
    {
        var serializationResult = rootSerializer.Serialize(manager, root);
        // handle the result here
    }

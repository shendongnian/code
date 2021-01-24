    var result = c.Entities
        .WithAttributeProjection(e => new
        {
            MapId = Extensions.GenerateMapId(), // We need mapping for this type
            Prop1 = e.Id,
            Prop2 = e.Name,
            Prop3 = e.Child.Name,
            Nested = new
            {
                MapId = Extensions.GenerateMapId(), // Also for this type
                Prop1 = e.Id,
                Prop2 = e.Name,
                Prop3 = e.Child.Name,
                Children = e.ManyChild.Select(m => new WithMetadataMapping // This implements IWithMetadataMapping so it will get the mappgin automatically 
                {
                    Name = m.Name
                })
            }
        });
                    
    foreach (var item in result)
    {
        var map = Extensions.GetMapping(item.MapId); // Get the map for the outer new 
        var type = item.GetType(); 
        var prop2 = type.GetProperty(nameof(item.Prop2));
        var sourceProp2 = map.GetSourceMember(prop2);
        var value2 = sourceProp2.GetCustomAttribute<CustomAttribute1Attribute>().Value;
        Console.WriteLine(value2); // Entity.Name
                        
        var prop3 = type.GetProperty(nameof(item.Prop3));
        var sourceProp3 = map.GetSourceMember(prop3);
        var value3 = sourceProp3.GetCustomAttribute<CustomAttribute1Attribute>().Value;
        Console.WriteLine(value3); // ChildEntity.Name
        foreach (var child in item.Nested.Children)
        {
            var childMap = Extensions.GetMapping(child.MapId);
            var nameProp = child.GetType().GetProperty(nameof(child.Name));
            var value = childMap.GetSourceMember(nameProp).GetCustomAttribute<CustomAttribute1Attribute>().Value;
            Console.WriteLine(value); // ManyChildEntity.Name
        }
    }

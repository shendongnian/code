    Entity ea = new Entity();
    ea.Id = Guid.NewGuid();
    var li = new List<Entity>();
    li.Add(new Entity { Id = Guid.NewGuid() });
    ea.ChildEntity = li;
    DeepClone<Entity>(ea);

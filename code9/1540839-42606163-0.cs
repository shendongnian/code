     // this will find classes which, like RepoTest, are derived from Test<>
    var allDerivedTypes = typeof(Test<>).Assembly.GetExportedTypes().Where(x => x.BaseType.IsGenericType && x.BaseType.GetGenericTypeDefinition() == typeof(Test<>)).ToList();
    
    // ideally, you'd find some way to constrain all your models.
    // what you need for this foreach is all of the entities that can be present in things like RepoTest
    foreach(var t in typeof(Tool).Assembly.GetExportedTypes())
    {
        // For each entity, get a runtime representation of Test<Entity>
        var targetType = typeof(Test<>).MakeGenericType(t);
        
        // Check if there is a class derived from Test<Entity>
        var potentiallyPresentImplementation = allDerivedTypes.FirstOrDefault(x => targetType == x.BaseType); // here you might want to decide how to handle multiple instances of the same generic base
    
        // Found one, so bind it
        if(potentiallyPresentImplementation != null)
        {
            kernel.Bind(targetType ).To(potentiallyPresentImplementation ).InRequestScope();
        }
    }

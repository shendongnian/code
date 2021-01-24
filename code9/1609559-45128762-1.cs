    [TestMethod]
    public void Resolve_CanResolveAllTypes()
    {
        foreach (var componentRegistration in _container.ComponentRegistry.Registrations)
        {
            foreach (var registrationService in componentRegistration.Services)
            {
                var registeredTargetType = registrationService.Description;
                var type = GetType(registeredTargetType);
                if (type == null)
                {
                    Assert.Fail($"Failed to parse type '{registeredTargetType}'");
                }
                var instance = _container.Resolve(type);
                Assert.IsNotNull(instance);
                Assert.AreEqual(componentRegistration.Activator.LimitType, instance.GetType());
            }
        }
    }
    
    private static Type GetType(string typeName)
    {
        var type = Type.GetType(typeName);
        if (type != null)
        {
            return type;
        }
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            type = assembly.GetType(typeName);
            if (type != null)
            {
                return type;
            }
        }
        return null;
    }

        string name = getName(type);
        var lifetimeManager = getLifetimeManager(type);
        var members = getInjectionMembers(type).ToList();
        // UnityContainerRegistrationByConventionExtensions.RegisterTypeMappings(container, ...) – It's invocation of common registration 
        // for current type to getFromTypes(type). getFromTypes is WithMappings.FromMatchingInterface in your case
        if (lifetimeManager != null || members.Count > 0)
            container.RegisterType(type, name, lifetimeManager, members);

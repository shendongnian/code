        string name = getName(type);
        var lifetimeManager = getLifetimeManager(type);
        var members = getInjectionMembers(type).ToList();
        // UnityContainerRegistrationByConventionExtensions.RegisterTypeMappings(container,...) – It's a invocation of common registration for current type to getFromTypes(type)
        if (lifetimeManager != null || members.Count > 0)
            container.RegisterType(type, name, lifetimeManager, members);

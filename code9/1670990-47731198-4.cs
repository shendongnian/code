    commandReg.Dependencies.Add(
        commandReg.Constructor.GetParameters().First(
            p => p.ParameterType.IsGenericType && p.ParameterType.GetGenericTypeDefinition() == typeof(ILogDifferencesLogger<>)).Name, 
            new GenericTypesWorkaroundInstance(
                loggers[AppSettingsManager.Get("logDifferences:Target")],
                // specify which types are correct
                types => types.Skip(1).ToArray()));

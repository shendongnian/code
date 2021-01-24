        foreach (var type in assembly.GetTypes())
        {
            var constructors = type.GetConstructors();
            var fields = type.GetFields();
            var properties = type.GetProperties();
            ...
        }

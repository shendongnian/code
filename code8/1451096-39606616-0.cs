    var types =
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(typ => typ.BaseType == typeof(P))
                .OrderBy(typ=>typ.Name)
                .Select(typ => typ.GetConstructors().First()).ToArray();
        var a = (P)types[0].Invoke(null);
        var y = (P)types[3].Invoke(null);
        var x = (P)types[2].Invoke(null);
        var b = (P)types[1].Invoke(null);

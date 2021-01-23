    var definedTypes = Assembly.LoadFile("file").DefinedTypes;
    foreach(var t in definedTypes)
    {
        foreach(var m in t.GetMethods())
        {
            var parameters = m.GetParameters();
            if (parameters.Length ==1 && parameters[0].ParameterType == typeof(FileInfo))
            {
                var instanse = Activator.CreateInstance(t);
                m.Invoke(instanse, new[] { fileInfo });
             }
         }
    }

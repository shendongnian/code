    var compilation = document.GetSemanticModelAsync().Result.Compilation;
    using (MemoryStream ms = new MemoryStream())
    {
        var emitResult = compilation.Emit(ms);
        var assembly = Assembly.Load(ms.GetBuffer());
        Type t = assembly.GetTypes().First();
    
        var res = t.GetMethod("<Factory>").Invoke(null, new object[] { new object[] { Activator.CreateInstance(_customType), null } });
    }

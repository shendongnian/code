    AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => {
        // Either hardcode the appropriate namespace or retrieve it at runtime in a way that makes sense for your project.
        string resourceName = string.Concat("My.Namespace.Resources.", name, ".dll");
        using(var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)) {
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return Assembly.Load(buffer);
        }
    };

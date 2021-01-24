        var assembly = typeof(App).GetTypeInfo().Assembly;
        foreach (var res in assembly.GetManifestResourceNames())
        {
            System.Diagnostics.Debug.WriteLine("found resource: " + res);
        }

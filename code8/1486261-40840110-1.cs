    protected internal void SqlResource(string sqlResource, Assembly resourceAssembly = null, bool suppressTransaction = false, object anonymousArguments = null)
    {
        Check.NotEmpty(sqlResource, "sqlResource");
        resourceAssembly = resourceAssembly ?? Assembly.GetCallingAssembly();
        if (!resourceAssembly.GetManifestResourceNames().Contains(sqlResource))
        {
                throw new ArgumentException(Strings.UnableToLoadEmbeddedResource(resourceAssembly.FullName, sqlResource));
        }
        using (var textStream = new StreamReader(resourceAssembly.GetManifestResourceStream(sqlResource)))
        {
            AddOperation(
                new SqlOperation(textStream.ReadToEnd(), anonymousArguments)
                    {
                        SuppressTransaction = suppressTransaction
                    });
        }
    }

    Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        var location = Path.Combine(
            Path.GetDirectoryName(typeof(MyForm).Assembly.Location),
            CultureInfo.CurrentCulture.Parent.Name,
            args.Name.Substring(0, args.Name.IndexOf(",", StringComparison.OrdinalIgnoreCase)) + ".dll");
        if (File.Exists(location))
        {
            return Assembly.LoadFrom(location);
        }
        return null;
        }
    }

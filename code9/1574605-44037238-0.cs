    public static class Bootstrapper
	{
    //...
    public static IEnumerable<Assembly> GetAssemblies(this object o)
		{
			IEnumerable<Assembly> assemblies =
            new[]
            {
                o.GetType().GetTypeInfo().Assembly,
                typeof(ShellViewModel).GetTypeInfo().Assembly
            };
			return assemblies;
		}
    //...
    }

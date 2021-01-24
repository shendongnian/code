    RedirectAssembly("System.Private.CoreLib", "mscorlib");
    
    public static void RedirectAssembly(string fromAssemblyShotName, string replacmentAssemblyShortName)
    {
        Console.WriteLine($"Adding custom resolver redirect rule form:{fromAssemblyShotName}, to:{replacmentAssemblyShortName}");
        ResolveEventHandler handler = null;
        handler = (sender, args) =>
        {
            // Use latest strong name & version when trying to load SDK assemblies
            var requestedAssembly = new AssemblyName(args.Name);
            Console.WriteLine($"RedirectAssembly >  requesting:{requestedAssembly}; replacment from:{fromAssemblyShotName}, to:{replacmentAssemblyShortName}");
            if (requestedAssembly.Name == fromAssemblyShotName)
            {
                try
                {
                    Console.WriteLine($"Redirecting Assembly {fromAssemblyShotName} to: {replacmentAssemblyShortName}");
                    var replacmentAssembly = Assembly.Load(replacmentAssemblyShortName);
                    return replacmentAssembly;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ERROR while trying to provide replacement Assembly {fromAssemblyShotName} to: {replacmentAssemblyShortName}");
                    Console.WriteLine(e);
                    return null;
                }
            }
    
            Console.WriteLine($"Framework faild to find {requestedAssembly}, trying to provide replacment from:{fromAssemblyShotName}, to:{replacmentAssemblyShortName}");
    
            return null;
        };
    
        AppDomain.CurrentDomain.AssemblyResolve += handler;
    }

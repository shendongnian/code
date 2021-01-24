     protected void Application_Start()
      {
                 AppDomain currentDomain = AppDomain.CurrentDomain;
     
                 currentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
     
     }
     
     static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
     {
                 var pluginsFolder = GetPluginFolder()
             return (from f in pluginsFolder.GetFiles("*.dll", SearchOption.AllDirectories)
                         let assemblyName = AssemblyName.GetAssemblyName(f.FullName)
                         where assemblyName.FullName == args.Name || assemblyName.FullName.Split(',')[0] == args.Name
                         select Assembly.LoadFile(f.FullName)).FirstOrDefault();
     }

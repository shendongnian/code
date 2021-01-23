    var theAssembly = (
        from Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()
        where (assembly.FullName == "TheNamespace.AssemblyName")
        select assembly
    )
    .FirstOrDefault();
    
    if ( theAssembly!= null ){
        Type theType = theAssembly.GetType(scenario1);
        var theInstance = (IGetInfoAware)Activator.CreateInstance(theType);
        theInstance.GetInfo();
    }

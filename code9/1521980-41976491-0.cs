    foreach (var asm in AppDomain.CurrentDomain.GetAssemblies().Where(IsMyAssembly))
                {
                    foreach (var type in asm.GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IDataValidator))))
                    {
    //...

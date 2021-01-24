        try
        {
            foreach(Assembly moduleAssembly in installationModules)
            {
                // satellite proejct assemblies 
                Debug.WriteLine(moduleAssembly.FullName);
                ContainerRegisterEventSource.Log.InstallAssembly(moduleAssembly.FullName);
                container.Install(FromAssembly.Instance(moduleAssembly));
            }
            container.Install(FromAssembly.This()); // the core assembly
        }
        catch(Exception exception)
        {
            ContainerRegisterEventSource.Log.Exception(exception.Message + exception.StackTrace);
            Trace.WriteLine("SetupContainerForMigrations error : " + exception.Message + Environment.NewLine + exception.StackTrace);
        }
   

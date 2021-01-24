    var query = from service in TryResolveCollection<ICommunicationService>(container)
                let serviceType = service.GetType()
                let serviceAssembly = serviceType.GetTypeInfo().Assembly
                let assemblyName = serviceAssembly.GetName().Name
                let version = serviceAssembly.GetName().Version.ToString()
                select new { service, assemblyName, version };

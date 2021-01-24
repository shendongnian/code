    var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
                var container = new CompositionContainer(catalog);
    
                var implementer = new Implementer();
                container.ComposeParts(implementer);
                //var IdoNotCompile = new TwoWayMessageHubService(new Logger());
    
                Console.ReadLine();

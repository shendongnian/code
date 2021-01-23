            _engine = new MDbgEngine();
            _engine.Attach(p.Id, RuntimeEnvironment.GetSystemVersion());
            _engine.Processes.Active.Go().WaitOne();
            foreach (MDbgAppDomain appDomain in _engine.Processes.Active.AppDomains) {
                foreach (CorAssembly assembly in appDomain.CorAppDomain.Assemblies) {
                    Console.WriteLine(assembly.Name);
                }
                
            }

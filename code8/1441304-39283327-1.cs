     private Assembly Loader_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly assembly = null;
            //1. Disconnect the event AssemblyResolve
            _Domain.AssemblyResolve -= new ResolveEventHandler(Loader_AssemblyResolve);
            try
            {
                //2. Do not try to get the file without looking first
                //   in memory. AssemblyResolve could fire even when the
                //   Assembly is already loaded
                assembly = System.Reflection.Assembly.Load(args.Name);
                if (assembly != null)
                {
                    _Domain.AssemblyResolve += new ResolveEventHandler(Loader_AssemblyResolve);
                    return assembly;
                }
            }
            catch
            { // ignore load error 
            }
            //3. Then try to get it from file
            string FileName=GetFileName(args.Name);
            try
            {
                assembly = System.Reflection.Assembly.LoadFrom(FileName);
                if (assembly != null)
                {
                    _Domain.AssemblyResolve += new ResolveEventHandler(Loader_AssemblyResolve);
                    return assembly;
                }
            }
            catch
            { // ignore load error 
            }            
            //Be sure to reconnect the event
            _Domain.AssemblyResolve += new ResolveEventHandler(Loader_AssemblyResolve);
            return assembly;
        }

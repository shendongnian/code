        protected void Application_Start()
        {
            ...
            using (new Mutex(true, "ignite_" + Process.GetCurrentProcess().Id))
            {
                var ignite = Ignition.TryGetIgnite() ?? Ignition.Start();
            }
        }
 
        protected void Application_End()
        {
            using (new Mutex(true, "ignite_" + Process.GetCurrentProcess().Id))
            {
                Ignition.StopAll(true);
            }
        }

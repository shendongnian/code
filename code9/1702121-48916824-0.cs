        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigurePlugins(app);
        }
        private static void ConfigurePlugins(IAppBuilder app)
        {
            try
            {
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    var startups = assembly.GetTypes().Where(x => x.IsClass && typeof(IAppConfiguration ).IsAssignableFrom(x)).ToList();
                    foreach (Type startup in startups)
                    {
                        var config = (IAppConfiguration )Activator.CreateInstance(startup);
                        config.Configuration(app);
                    }
                }
            }
            catch
            {
            }
        }

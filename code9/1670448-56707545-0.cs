        public void ConfigureServices(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            var outputProcess = sp.GetService<IOutputProcess>();
            services.AddMvc().AddApplicationPart(outputProcess.ControllerAssembly).AddControllersAsServices();
        }

    public Startup(IHostingEnvironment env)
        {
            if (env.EnvironmentName== "Production")
            {
                //env.ContentRootPath = "/var/aspnetcore/my_ASP_app";
                env.ContentRootPath = System.IO.Directory.GetCurrentDirectory();
            }
            //env.ContentRootPath = System.IO.Directory.GetCurrentDirectory();//you can write this line outside of IF block.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

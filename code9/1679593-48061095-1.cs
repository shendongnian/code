        public void ConfigureServices(IServiceCollection services)
        {
            //..
            services.Configure<RazorViewEngineOptions>(o =>
            {
                for (int i = 0; i < o.ViewLocationFormats.Count; i++)
                    o.ViewLocationFormats[i] = "/src" + o.ViewLocationFormats[i];
            });
        }

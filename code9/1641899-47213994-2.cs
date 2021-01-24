    public void ConfigureServices(IServiceCollection services)
        {
            services
            .AddMvc()
            .AddRazorPagesOptions( options =>
            {
                options.Conventions.AddPageRoute( "/foo", "foo/{handler?}" );
            } );
        }

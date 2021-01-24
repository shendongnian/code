    public IServiceProvider ConfigureServices(IServiceCollection services) {
      services.AddMvc();
      var builder = new ContainerBuilder();
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddSingleton<IUserContextProvider, MvcUserContextProvider>();
      services.AddDbContext<ApplicationContext>(options => {
        
      options.UseNpgsql(
        Configuration.GetConnectionString("ApplicationContext"));
      });
      services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationContext>()
        .AddDefaultTokenProviders();
      builder.Populate(services);
      this.ApplicationContainer = builder.Build();
      // Create the IServiceProvider based on the container.
      return new AutofacServiceProvider(this.ApplicationContainer);
    }
    public void Configure(
      IApplicationBuilder app,
      IHostingEnvironment env,
      ILoggerFactory loggerFactory,
      IApplicationLifetime appLifetime) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }
      loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();
      app.UseMvc();
      var userContexProvider = app.ApplicationServices.GetService<IUserContextProvider>();
      ApplicationContext.ConfigureOverrides(new List<IEntityFrameworkOverrides>(){
        new SoftDeleteOverrides(userContexProvider),
        new TrackCreatedOverride(userContexProvider),
        new TrackModifiedOverride(userContexProvider)
      });
      appLifetime.ApplicationStopped.Register(() => {
        this.ApplicationContainer.Dispose();
      });
    }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseMvc();
			//Logger for File
            loggerFactory.AddFile("FilePath/FileName-{Date}.txt");
        }
    }
	//Add following code into Controller:
	private readonly ILogger<ControllerName> _log;
	public ControllerConstructor(ILogger<ControllerName>logger)
	 {
		  _log = logger;
	 }
	[HttpGet]
	public ActionResult GetExample()
	{
		try
		{
			//TODO:Log Informationenter code here
			_log.LogInformatio("LogInformation");
		}
		catch (Exception exception)
		{
			 //TODO: Log Exception
			 _log.LogError(exception, exception.Message + "\n\n");
		} 
		return view("viewName");
	}

    public class Startup
    {
    	public Startup(IHostingEnvironment hostingEnvironment)
    	{
    		Settings = new AppSettings(hostingEnvironment);
    	}
    
    	public AppSettings Settings { get; private set; }
    
    	public IServiceProvider ConfigureServices(IServiceCollection services)
    	{
    		services.AddMvc(); 
    		services.AddOptions();    	
    		// any other services registrations...    
    		var builder = new ContainerBuilder();    		
    		// all autofac registrations...
    		builder.Populate(services);
    		return new AutofacServiceProvider(builder.Build(););
    	}
    
    	public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    	{
    		if (env.IsDevelopment())
    		{
    			app.UseDeveloperExceptionPage();
    		}
    
    		app.UseMvc();
    	}
    }

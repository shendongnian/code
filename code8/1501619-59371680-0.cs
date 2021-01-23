        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    		{
                ...
    			app.UseSpa(spa =>
    			{
    				spa.Options.SourcePath = "client";
    
    				if (env.IsDevelopment())
    				{
    					spa.UseReactDevelopmentServer("start");
    				}
    			});
    		}

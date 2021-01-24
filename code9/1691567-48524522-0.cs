	public class Startup {
        public Startup(IConfiguration _configuration) {
            configuration = _configuration;
        }
		
        public IConfiguration configuration { get; }
        
        public void ConfigureServices(IServiceCollection services) {		
            services.AddCors();
            services.AddMvc();
			
			services.AddSignalR();
            services.AddTransient<ISubscriber, Subscriber>();
            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IHealthCheckProcessor, HealthCheckProcessor>();
            services.AddTransient<INodeProcessor, NodeProcessor>();
        }
        public void Configure(
			IApplicationBuilder app, 
			IHostingEnvironment env, 
			IApplicationLifetime applicationLifetime, 
			IServiceProvider sp
		) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
                // CORS stuff);
            
            app.UseMvc();
			
			app.UseSignalR(routes => {
                routes.MapHub<StatusHub>("Status");
            });
			
			//At this point all the necessary dependencies have been registered and configured
			var subscriber = sp.GetService<ISubscriber>();
			
            applicationLifetime.ApplicationStarted.Register(() => OnStartup(subscriber));
            applicationLifetime.ApplicationStopping.Register(() => OnShutdown(subscriber));
        }
        private void OnStartup(ISubscriber subscriber) {
            // MessageBroker stuff
            subscriber.Start(messageBroker);
        }
        private void OnShutdown(ISubscriber subscriber) {
            subscriber.Stop();
        }
	}

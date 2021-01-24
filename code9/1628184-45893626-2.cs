        public void ConfigureServices(IServiceCollection services)
        {
            /* All other stuff here */ 
            // Adding Database connection
            services.AddDbContext<MyDbContext>(o => /* my options */);
            // Associates our database and store to identity
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MyDbContext>()
                .AddUserStore<MyIdentityStore>();
            // Claims transformation from database to claims
            services.AddTransient<IClaimsTransformer, MyClaimsTransformer>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            /* All other stuff here */ 
            app.UseIdentity();
            app.UseClaimsTransformation(async (context) =>
            { // Retrieve user claims from database
                IClaimsTransformer transformer = context.Context.RequestServices.GetRequiredService<IClaimsTransformer>();
                return await transformer.TransformAsync(context);
            });
        }

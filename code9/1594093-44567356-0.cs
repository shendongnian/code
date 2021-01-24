   var identity = new ClaimsIdentity(claims, "AuthenticationTypes.Federation");
Below is the corrected code
In Startup.cs
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCookieAuthentication("MyCookieMiddlewareInstance", o =>
            {
                o.LoginPath = new PathString("/Account/Login/");
                o.AccessDeniedPath = new PathString("/Account/Forbidden/");
            });
            services.AddAuthentication();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
In Controller
        using Microsoft.AspNetCore.Authentication;
        //...
        public async Task<IActionResult> Login()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "joe nobody")
            };
            var identity = new ClaimsIdentity(claims, "AuthenticationTypes.Federation");
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("MyCookieMiddlewareInstance", principal);
            return View();
        }

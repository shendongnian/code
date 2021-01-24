    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "myauth1";
            })
    
           .AddCookie("myauth1");
           .AddCookie("myauth2");
        }
    
        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
    
            app.Use(async (context, next) =>
            {
                var principal = new ClaimsPrincipal();
    
                var result1 = await context.AuthenticateAsync("myauth1");
                if (result1?.Principal != null)
                {
                    principal.AddIdentities(result1.Principal.Identities);
                }
    
                var result2 = await context.AuthenticateAsync("myauth2");
                if (result2?.Principal != null)
                {
                    principal.AddIdentities(result2.Principal.Identities);
                }
    
                context.User = principal;
    
                await next();
            });
    
            // ...
        }
    }

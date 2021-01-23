    using Swashbuckle.AspNetCore.Swagger;
    using System;
    using Microsoft.Extensions.PlatformAbstractions;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Authorization;
    using WebAPI.Options;
    namespace WebAPI
    {
        public class Startup
        {
             public static string ConnectionString { get; private set; }
             private const string SecretKey = "getthiskeyfromenvironment";
             private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
             public Startup(IHostingEnvironment env)
             {
                var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build(); 
            ConnectionString = Configuration.GetSection("ConnectionStrings").GetSection("<Your DB Connection Name>").Value;
        }
        public static IConfigurationRoot Configuration { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // ********************
            // Setup CORS
            // ********************
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin(); // For anyone access.
            //corsBuilder.WithOrigins("http://localhost:12345"); // for a specific url. Don't add a forward slash on the end!
            corsBuilder.AllowCredentials();
            services.AddCors(options =>
            {
                options.AddPolicy("<YourCorsPolicyName>", corsBuilder.Build());
            });
            var xmlPath = GetXmlCommentsPath();
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "XYZ API", Version = "v1", Description = "This is a API for XYZ client applications.", });
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme() { In = "header", Description = "Please paste JWT Token with Bearer + White Space + Token into field", Name = "Authorization", Type = "apiKey" });
            });
            // Add framework services.
            services.AddOptions();
            // Use policy auth.
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AuthorizationPolicy",
                                  policy => policy.RequireClaim("DeveloperBoss", "IAmBoss"));
            });
            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],
                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });
            //loggerFactory.AddLambdaLogger(Configuration.GetLambdaLoggerOptions());
            
            app.UseMvc();
            app.UseStaticFiles();
            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors("<YourCorsPolicyName>");
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
           // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUi(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "XYZ API V1");
            });
        }
        private string GetXmlCommentsPath()
        {
            var app = PlatformServices.Default.Application;
            return System.IO.Path.Combine(app.ApplicationBasePath, "WebAPI.xml");
        }
    }

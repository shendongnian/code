    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Protocols.OpenIdConnect;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.AspNetCore.Authentication;
    using MyApp.Utils;
    using Microsoft.Graph;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Authorization;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    
    namespace MyApp
    {
        public class Startup
        {
            public static string ClientId;
            public static string ClientSecret;
            public static string Authority;
            public static string GraphResourceId;
            public static string ApiVersion;
            public Startup(IHostingEnvironment env)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
    
                if (env.IsDevelopment())
                {
                    // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                    builder.AddUserSecrets();
                }
                builder.AddEnvironmentVariables();
                Configuration = builder.Build();
            }
    
            public IConfigurationRoot Configuration { get; set; }
    
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                // Add Session services
                services.AddSession();
    
                // Add Auth
                services.AddAuthentication(
                    SharedOptions => SharedOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);
    
                services.AddMvc(config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                    .Build();
    
                    config.Filters.Add(new AuthorizeFilter(policy));
                });
    
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                // Configure session middleware.
                app.UseSession();
    
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
    
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseBrowserLink();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }
    
                app.UseStaticFiles();
    
                // Populate AzureAd Configuration Values 
    
                ClientId = Configuration["AzureAd:ClientId"];
                ClientSecret = Configuration["AzureAd:ClientSecret"];
                GraphResourceId = Configuration["AzureAd:GraphResourceId"];
                Authority = Configuration["AzureAd:AadInstance"] + Configuration["AzureAd:TenantId"];
                ApiVersion = Configuration["AzureAd:ApiVersion"];
    
                // Implement Cookie Middleware For OpenId
                app.UseCookieAuthentication();
                // Set up the OpenId options
                app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
                {
                    ClientId = Configuration["AzureAd:ClientId"],
                    ClientSecret = Configuration["AzureAd:ClientSecret"],
                    Authority = Configuration["AzureAd:AadInstance"] + Configuration["AzureAd:TenantId"],
                    CallbackPath = Configuration["AzureAd:CallbackPath"],
                    ResponseType = OpenIdConnectResponseType.CodeIdToken,
                    Events = new OpenIdConnectEvents
                    {
                        OnRemoteFailure = OnAuthenticationFailed,
                        OnAuthorizationCodeReceived = OnAuthorizationCodeReceived,
                    },
    
                    TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        NameClaimType = "name",
                    },
                    GetClaimsFromUserInfoEndpoint = true,
                    SaveTokens = true
                });
    
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
    
            }
    
            private async Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
            {
                // Acquire a Token for the Graph API and cache it using ADAL.
                string userObjectId = (context.Ticket.Principal.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier"))?.Value;
                ClientCredential clientCred = new ClientCredential(ClientId, ClientSecret);
    
                // Gets Authentication Tokens From Azure
                AuthenticationContext authContext = new AuthenticationContext(Authority, new NaiveSessionCache(userObjectId, context.HttpContext.Session));
    
                // Gets the Access Token To Graph API
                AuthenticationResult authResult = await authContext.AcquireTokenByAuthorizationCodeAsync(
                    context.ProtocolMessage.Code, new Uri(context.Properties.Items[OpenIdConnectDefaults.RedirectUriForCodePropertiesKey]), clientCred, GraphResourceId);
    
                // Gets the Access Token for Application Only Permissions
                AuthenticationResult clientAuthResult = await authContext.AcquireTokenAsync(GraphResourceId, clientCred);
    
                // The user's unique identifier from the signin event
                string userId = authResult.UserInfo.UniqueId;
    
                // Get the users roles and groups from the Graph Api. Then return the roles and groups in a new identity
                ClaimsIdentity identity = await GetUsersRoles(clientAuthResult.AccessToken, userId);
    
                // Add the roles to the Principal User
                context.Ticket.Principal.AddIdentity(identity);
    
                // Notify the OIDC middleware that we already took care of code redemption.
                context.HandleCodeRedemption();
            }
    
            // Handle sign-in errors differently than generic errors.
            private Task OnAuthenticationFailed(FailureContext context)
            {
                context.HandleResponse();
    
                context.Response.Redirect("/Home/Error?message=" + context.Failure.Message);
                return Task.FromResult(0);
            }
    
            // Get user's roles as the Application
            /// <summary>
            /// Returns user's roles and groups as a ClaimsIdentity
            /// </summary>
            /// <param name="accessToken">accessToken retrieved using the client credentials and the resource (Hint: NOT the accessToken from the signin event)</param>
            /// <param name="userId">The user's unique identifier from the signin event</param>
            /// <returns>ClaimsIdentity</returns>
            private async Task<ClaimsIdentity> GetUsersRoles(string accessToken, string userId)
            {
                ClaimsIdentity identity = new ClaimsIdentity("LocalIds");
    
                var serializer = new Serializer();
    
                string resource = GraphResourceId + ApiVersion + "/users/" + userId + "/memberOf";
    
                var client = new HttpClient();
    
                var request = new HttpRequestMessage(HttpMethod.Get, new Uri(resource));
    
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    
                var response = await client.SendAsync(request);
    
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
    
                    var claims = new List<Claim>();
    
                    var responseClaims = serializer.DeserializeObject<Microsoft.Graph.UserMemberOfCollectionWithReferencesResponse>(responseString);
                    if (responseClaims.Value != null)
                    {
                        foreach (var item in responseClaims.Value)
                        {
                            if (item.ODataType == "#microsoft.graph.group")
                            {
                                // Serialize the Directory Object
                                var gr = serializer.SerializeObject(item);
                                // Deserialize into a Group
                                var group = serializer.DeserializeObject<Microsoft.Graph.Group>(gr);
                                if (group.SecurityEnabled == true)
                                {
                                    claims.Add(new Claim(ClaimTypes.Role, group.DisplayName));
                                }
                                else
                                {
                                    claims.Add(new Claim("group", group.DisplayName));
                                }
                            }
                        }
                    }
                    identity.AddClaims(claims);
                }
                return identity;
            }
    
        }
    }

        public class AdAuthorizationMiddleware
        {
        
            private readonly string _groupsAndUsersConfigField = "AuthenticationGroupsAndUsers";
            private readonly List<string> _authorizedGroupAndUsers;
            private IConfigurationRoot _configuration { get; }
            private readonly RequestDelegate _next;
            public AdAuthorizationMiddleware(RequestDelegate next)
            {
                // Read and save app settings
                _configuration = GetConfiguration();
                _authorizedGroupAndUsers = _configuration[_groupsAndUsersConfigField].Split(',').ToList();
            
                _next = next;
            }
            public async Task Invoke(HttpContext context)
            {
                // Check does user belong to an authorized group or not
                var isAuthorized = _authorizedGroupAndUsers.Any(i => context.User.IsInRole(i));
                // Return error if the current user is not authorized
                if (!isAuthorized){
                    context.Response.StatusCode = 403;
                    return;
                }
                // Jump to the next middleware if the user is authorized
                await _next.Invoke(context);
            }
            private static IConfigurationRoot GetConfiguration()
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
                Console.WriteLine("Configuration is loaded");
                return builder.Build();
            }
        }

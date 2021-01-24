    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace()
                .CreateLogger();
            var users = new List<InMemoryUser>()
            {
                new InMemoryUser
                {
                    Username="Jack", Password="Jack",
                    Claims= new List<Claim>
                    {
                        new Claim("name","Jack"),
                        new Claim("email","Jack@consoto.com"),
                        new Claim("role","Admin"),
                    }
                }
            };
            var clients = new Client[]
            {
                new Client
                {
                    ClientId="mvc",
                    ClientName="MVC Demo Client",
                    Flow=Flows.Implicit,
                    RedirectUris=new List<string>
                    {
                        "http://localhost:9000",
                        "http://localhost:1409/"
                    },
                    AllowedScopes=new List<string>
                    {
                        "openid","email","profile","roles"
                    }
                }
            };
            var scopes = new Scope[]
                {
                    StandardScopes.OpenId,
                    StandardScopes.ProfileAlwaysInclude,
                    StandardScopes.EmailAlwaysInclude,
                    new Scope
                    {
                        Name="roles",
                        Claims=new List<ScopeClaim>
                        {
                            new ScopeClaim("role")
                        },
                        Type=ScopeType.Identity
                    }
                };
            var factory = new IdentityServerServiceFactory();
            factory.UseInMemoryClients(clients);
            factory.UseInMemoryScopes(scopes);
            factory.UseInMemoryUsers(users);
            var cert = LoadCertificate();
            app.UseIdentityServer(new IdentityServerOptions
            {
                SiteName = "NDC Demo",
                SigningCertificate = cert,
                Factory = factory,
                AuthenticationOptions = new AuthenticationOptions
                {
                    IdentityProviders = ConfigureAdditionalIdentityProviders,
                    EnableAutoCallbackForFederatedSignout = true
                }
            });
        }
        public static void ConfigureAdditionalIdentityProviders(IAppBuilder app, string signInAsType)
        {
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                AuthenticationType = "aad",
                Caption = "Azure AD",
                SignInAsAuthenticationType = signInAsType,
                Authority = "https://login.microsoftonline.com/04e14a2c-0e9b-42f8-8b22-3c4a2f1d8800",
                ClientId = "eca61fd9-f491-4f03-a622-90837bbc1711",
                RedirectUri = "https://localhost:44333/core/aadcb",
            });
        }
        static X509Certificate2 LoadCertificate()
        {
            var baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            string certificatePath = $"{baseFolder}\\Certificates\\mycompanyname.pfx";
            return new X509Certificate2(certificatePath, "", X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);
        }
    }

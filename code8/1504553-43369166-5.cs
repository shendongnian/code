    using IdentityServer4;
        using IdentityServer4.Models;
        using System.Collections.Generic;
        
        namespace IdentityAuthority.Configs
        {
        
            public class IdentityServerConfig
            {
        
                // scopes define the resources in your system
                public static IEnumerable<IdentityResource> GetIdentityResources()
                {
                    return new List<IdentityResource>
                    {
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile()
                    };
                }
        
                // scopes define the API resources
                public static IEnumerable<ApiResource> GetApiResources()
                {
                    //Create api resource list
                    List<ApiResource> apiResources = new List<ApiResource>();
        
                    //Add Application Api API resource
                    ApiResource applicationApi = new ApiResource("ApplicationApi", "Application Api");
                    applicationApi.Description = "Application Api resource.";
                    apiResources.Add(applicationApi);
        
                    //Add Application Api API resource
                    ApiResource definitionApi = new ApiResource("DefinitionApi", "Definition Api");
                    definitionApi.Description = "Definition Api.";
                    apiResources.Add(definitionApi);
        
                    //Add FF API resource
                    ApiResource ffApi = new ApiResource("FFAPI", "Fule .netfx API");
                    ffApi.Description = "Test using .net 4.5 API application with IdentityServer3.AccessTokenValidation";
                    apiResources.Add(ffApi);
        
                    return apiResources;
                }
        
                // client want to access resources (aka scopes)
                public static IEnumerable<Client> GetClients()
                {
                    //Create clients list like webui, console applications and...
                    List<Client> clients = new List<Client>();
        
                    //Add WebUI client
                    Client webUi = new Client();
                    webUi.ClientId = "U2EQlBHfcbuxUo";
                    webUi.ClientSecrets.Add(new Secret("TbXuRy7SSF5wzH".Sha256()));
                    webUi.ClientName = "WebUI";
                    webUi.AllowedGrantTypes = GrantTypes.HybridAndClientCredentials;
                    webUi.RequireConsent = false;
                    webUi.AllowOfflineAccess = true;
                    webUi.AlwaysSendClientClaims = true;
                    webUi.AlwaysIncludeUserClaimsInIdToken = true;
                    webUi.AllowedScopes.Add(IdentityServerConstants.StandardScopes.OpenId);
                    webUi.AllowedScopes.Add(IdentityServerConstants.StandardScopes.Profile);
                    webUi.AllowedScopes.Add("ApplicationApi");
                    webUi.AllowedScopes.Add("DefinitionApi");
                    webUi.AllowedScopes.Add("FFAPI");
                    webUi.ClientUri = "http://localhost:5003";
                    webUi.RedirectUris.Add("http://localhost:5003/signin-oidc");
                    webUi.PostLogoutRedirectUris.Add("http://localhost:5003/signout-callback-oidc");
                    clients.Add(webUi);
        
                    //Add IIS test client
                    Client iisClient = new Client();
                    iisClient.ClientId = "b8zIsVfAl5hqZ3";
                    iisClient.ClientSecrets.Add(new Secret("J0MchGJC8RzY7J".Sha256()));
                    iisClient.ClientName = "IisClient";
                    iisClient.AllowedGrantTypes = GrantTypes.HybridAndClientCredentials;
                    iisClient.RequireConsent = false;
                    iisClient.AllowOfflineAccess = true;
                    iisClient.AlwaysSendClientClaims = true;
                    iisClient.AlwaysIncludeUserClaimsInIdToken = true;
                    iisClient.AllowedScopes.Add(IdentityServerConstants.StandardScopes.OpenId);
                    iisClient.AllowedScopes.Add(IdentityServerConstants.StandardScopes.Profile);
                    iisClient.AllowedScopes.Add("ApplicationApi");
                    iisClient.AllowedScopes.Add("DefinitionApi");
                    iisClient.AllowedScopes.Add("FFAPI");
                    iisClient.ClientUri = "http://localhost:8080";
                    iisClient.RedirectUris.Add("http://localhost:8080/signin-oidc");
                    iisClient.PostLogoutRedirectUris.Add("http://localhost:8080/signout-callback-oidc");
                    clients.Add(iisClient);
        
                    return clients;
                }
        
            }
        }

    var authContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext("https://login.microsoftonline.com/tenantId");
    
                string tenantId = ConfigurationManager.AppSettings.Get("ida:TenantId");
                string clientId = ConfigurationManager.AppSettings.Get("ida:ClientId");
    
                String certPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/cert.pfx");
                X509Certificate2 cert = new X509Certificate2(
                    certPath,
                    "keyPwd",
                    X509KeyStorageFlags.MachineKeySet);
    
                ClientAssertionCertificate cac = new ClientAssertionCertificate(clientId, cert);
    
                var result = (AuthenticationResult)authContext
                    .AcquireTokenAsync("https://outlook.office.com", cac)
                    .Result;
                var token = result.AccessToken;
    
                return token;

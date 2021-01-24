    using Google.Apis.AnalyticsReporting.v4;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using System;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    
    namespace GoogleAnaltyics.V4
    {
        public class ServiceAccountJson
        {
            public string type { get; set; }
            public string project_id { get; set; }
            public string private_key_id { get; set; }
            public string private_key { get; set; }
            public string client_email { get; set; }
            public string client_id { get; set; }
            public string auth_uri { get; set; }
            public string token_uri { get; set; }
            public string auth_provider_x509_cert_url { get; set; }
            public string client_x509_cert_url { get; set; }
        }
    
    
        public class ServiceAccountAuthExample
        {
    
            /// <summary>
            /// Authenticating to Google using a Service account
            /// Documentation: https://developers.google.com/accounts/docs/OAuth2#serviceaccount
            /// </summary>
            /// <param name="serviceAccountEmail">From Google Developer console https://console.developers.google.com</param>
            /// <param name="serviceAccountCredentialFilePath">Location of the .p12 or Json Service account key file downloaded from Google Developer console https://console.developers.google.com</param>
            /// <returns>AnalyticsService used to make requests against the Analytics API</returns>
            public static AnalyticsReportingService AuthenticateServiceAccount(string serviceAccountEmail, string serviceAccountCredentialFilePath)
            {
                try
                {
                    if (string.IsNullOrEmpty(serviceAccountCredentialFilePath))
                        throw new Exception("Path to the .p12 service account credentials file is required.");
                    if (!File.Exists(serviceAccountCredentialFilePath))
                        throw new Exception("The service account credentials .p12 file does not exist at: " + serviceAccountCredentialFilePath);
                    if (string.IsNullOrEmpty(serviceAccountEmail))
                        throw new Exception("ServiceAccountEmail is required.");
    
                    // These are the scopes of permissions you need. It is best to request only what you need and not all of them
                    string[] scopes = new string[] { AnalyticsReportingService.Scope.Analytics };             // View your Google Analytics data
    
                    // For Json file
                    if (Path.GetExtension(serviceAccountCredentialFilePath).ToLower() == ".json")
                    {
                        GoogleCredential credential;
                        using (var stream = new FileStream(serviceAccountCredentialFilePath, FileMode.Open, FileAccess.Read))
                        {
                            credential = GoogleCredential.FromStream(stream)
                                 .CreateScoped(scopes);
                        }
    
                        // Create the  Analytics service.
                        return new AnalyticsReportingService(new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = credential,
                            ApplicationName = "Analytics Authentication Sample",
                        });
                    }
                    else if (Path.GetExtension(serviceAccountCredentialFilePath).ToLower() == ".p12")
                    {   // If its a P12 file
    
                        var certificate = new X509Certificate2(serviceAccountCredentialFilePath, "notasecret", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
                        var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
                        {
                            Scopes = scopes
                        }.FromCertificate(certificate));
    
                        // Create the  Analytics service.
                        return new AnalyticsReportingService(new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = credential,
                            ApplicationName = "Analytics Authentication Sample",
                        });
    
                    }
                    else
                    {
                        throw new Exception("Unsupported Service accounts credentials.");
                    }
    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Create service account AnalyticsService failed" + ex.Message);
                    throw new Exception("CreateServiceAccountAnalyticsServiceFailed", ex);
                }
            }
    
            /// <summary>
            /// Authenticating to Google using a Service account
            /// Documentation: https://developers.google.com/accounts/docs/OAuth2#serviceaccount
            /// </summary>
            /// <param name="serviceAccountEmail">From Google Developer console https://console.developers.google.com</param>
            /// <param name="key">Key from with in json file   
            /// 
            /// Example:
            /// ServiceAccountAuth tmp = JsonConvert.DeserializeObject<ServiceAccountAuth>(File.ReadAllText(serviceAccountJsonPath));
            /// 
            /// </param>
            /// <returns>AnalyticsService used to make requests against the Analytics API</returns>
            public static AnalyticsReportingService AuthenticateServiceAccountFromKey(string serviceAccountEmail, string key)
            {
                try
                {
                    if (string.IsNullOrEmpty(key))
                        throw new Exception("Key is required.");
                    if (string.IsNullOrEmpty(serviceAccountEmail))
                        throw new Exception("ServiceAccountEmail is required.");
    
                    // These are the scopes of permissions you need. It is best to request only what you need and not all of them
                    string[] scopes = new string[] { AnalyticsReportingService.Scope.Analytics };             // View your Google Analytics data
    
    
                    var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
                    {
                        Scopes = scopes
                    }.FromPrivateKey(key));
    
    
                    // Create the  Analytics service.
                    return new AnalyticsReportingService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Analytics Authentication Sample",
                    });
    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Create service account AnalyticsService failed" + ex.Message);
                    throw new Exception("CreateServiceAccountAnalyticsServiceFailed", ex);
                }
            }
    
        }
    }

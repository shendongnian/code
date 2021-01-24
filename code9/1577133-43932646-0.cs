    static async Task<UserCredential> GetCredential()
        {
            try
            {
                string jsonPath = System.Configuration.ConfigurationManager.AppSettings["VPJSON"].ToString() + "\\client_secret.json";
                HttpContext.Current.Response.Write("JSON PATH: " + jsonPath);
                using (var stream = new FileStream(jsonPath, FileMode.Open, FileAccess.Read))
                {
                    const string loginEmailAddress = "marketing@easyconsulting.com";
                    HttpContext.Current.Response.Write("\n EMAIL LOGIN: " + loginEmailAddress + "\n");
                    GoogleClientSecrets clientSecrets = GoogleClientSecrets.Load(stream);
                    HttpContext.Current.Response.Write("\n" + "CLIENT SECRET: " + clientSecrets.Secrets.ClientSecret + "\n");
                    HttpContext.Current.Response.Write("\n" + "CLIENT ID: " + clientSecrets.Secrets.ClientId + "\n\n");
                    string pathFileDataStore = "d:\\GADataStore";
                    FileDataStore ds = new FileDataStore(pathFileDataStore,true);
                    HttpContext.Current.Response.Write("\n" + "PATH FILE DATA STORE: " + ds.FolderPath + "\n");
                    return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        clientSecrets.Secrets,
                        new[] { AnalyticsReportingService.Scope.Analytics },
                        loginEmailAddress, System.Threading.CancellationToken.None,
                        ds
                        );
                }
            }
            catch (Exception ex)
            {
                
                HttpContext.Current.Response.Write("\n" + "GetCredential() " + ex.Message);
                return null;
            }
        }

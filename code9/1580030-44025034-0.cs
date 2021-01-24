    Install-Package Microsoft.Azure.NotificationHubs
    
    using Microsoft.Azure.NotificationHubs;//Add namespace
    
    
    string accessTokenstring = GetAccessToken();
    
     private string GetAccessToken()
            {
                var hubName = "<Notification Hub>";
                string connectionString = "Endpoint=sb://<Notification Hub Namespace>.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=<Key>";
                var apiVersion = "?api-version=2015-01";
                string endpoint = null;
                string sasKeyValue = null;
                string sasKeyName = null;
                string targetUri = null;
                var parts = connectionString.Split(';');
                foreach (var part in parts)
                {
                    if (part.IndexOf("Endpoint") == 0)
                    {
                        endpoint = "https" + part.Substring(11);
                    }
                    else if (part.IndexOf("SharedAccessKeyName") == 0)
                    {
                        sasKeyName = part.Substring(20);
                    }
                    else if (part.IndexOf("SharedAccessKey") == 0)
                    {
                        sasKeyValue = part.Substring(16);
                    }
                }
                targetUri = endpoint + hubName;
                var registrationPath = targetUri + "/Registrations/";
                var resourceUri = registrationPath + apiVersion;
                TimeSpan sinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1);
                string accessTokenstring = SharedAccessSignatureTokenProvider.GetSharedAccessSignature(sasKeyName, sasKeyValue, resourceUri, sinceEpoch);
                return accessTokenstring;
            }

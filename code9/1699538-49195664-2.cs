    // Example approved-clients.txt file in the approved-clients S3 bucket (us-east-1).
    //    //kid,key,active
    //    customer1,AAAAAAAAAAAAAAAA,true
    //    customer2,BBBBBBBBBBBBBBBB,true
    //    customer3,CCCCCCCCCCCCCCCC,true
    //    customer4,DDDDDDDDDDDDDDDD,true
    
    namespace My.CoreServices.Security.Jwt
    {
        public class SecurityKeyManager
        {
            private const int RELOAD_TIMER_DELAY_SECONDS = 3 * 1000;
            private const int RELOAD_TIMER_PERIOD_MINUTES = 60 * 60 * 1000;
    
            [DebuggerDisplay("{Kid}  {SymmetricKey}  {Active}")]
            internal class ApprovedClient
            {
                public string Kid { get; set; }
                public bool Active { get; set; }
                public string SymmetricKey { get; set; }
            };
    
            private static List<SymmetricSecurityKey> securityKeys = new List<SymmetricSecurityKey>();
    
            private static Timer reloadTimer = null;
    
            private static object keySync = new object();
    
            public static void Start()
            {
                // Start a new timer to reload all the security keys every RELOAD_TIMER_PERIOD_MINUTES.
                if (reloadTimer == null)
                {
                    reloadTimer = new Timer(async (t) =>
                    {
                        try
                        {
                            List<ApprovedClient> approvedClients = new List<ApprovedClient>();
    
                            Log.Debug("Pulling latest approved client symmetric keys for JWT signature validation");
    
                            string awsAccessKeyId = JwtConfigure.ConfigRoot["AWS:KeyManagement:AccessKeyId"];
                            string awsSecretAccessKey = fromBase64(JwtConfigure.ConfigRoot["AWS:KeyManagement:SecretAccessKey"]);
                            string awsRegion = JwtConfigure.ConfigRoot["AWS:KeyManagement:Region"];
    
                            using (var client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, RegionEndpoint.GetBySystemName(awsRegion)))
                            {
                                var request = new GetObjectRequest();
                                request.BucketName = JwtConfigure.ConfigRoot["AWS:KeyManagement:Bucket"];
                                request.Key = JwtConfigure.ConfigRoot["AWS:KeyManagement:Key"];
    
                                var response = await client.GetObjectAsync(request);
    
                                using (StreamReader sr = new StreamReader(response.ResponseStream))
                                {
                                    while (sr.Peek() > 0)
                                    {
                                        string line = await sr.ReadLineAsync();
    
                                        // Ignore comment lines in the approved-client file
                                        if (!line.StartsWith("//") && !string.IsNullOrEmpty(line))
                                        {
                                            // Each line of the file should only have 3 items:
                                            // kid, key, active
                                            string[] items = line.Split(',');
                                            approvedClients.Add(new ApprovedClient()
                                            {
                                                Kid = items[0],
                                                SymmetricKey = items[1],
                                                Active = Boolean.Parse(items[2])
                                            });
                                        }
                                    }
                                }
    
                            }
                            lock (keySync)
                            {
                                if (approvedClients.Count > 0)
                                {
                                    // Clear the security key list and repopulate
                                    securityKeys.Clear();
    
                                    foreach (var approvedClient in approvedClients)
                                    {
                                        if (approvedClient.Active)
                                        {
                                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(approvedClient.SymmetricKey));
                                            key.KeyId = approvedClient.Kid;
                                            securityKeys.Add(key);
                                        }
                                    }
                                }
                            }
    
                            Log.Information($"Reloaded security keys");
                        }
                        catch (Exception ex)
                        {
                            Log.Warning($"Error getting current security keys - {ex.Message}");
                        }
                    }, null, RELOAD_TIMER_DELAY_SECONDS, RELOAD_TIMER_PERIOD_MINUTES);
                }
            }
    
            public static void Stop()
            {
                if (reloadTimer != null)
                {
                    reloadTimer.Dispose();
                    reloadTimer = null;
                }
            }
    
            public static SymmetricSecurityKey GetSecurityKey(string kid)
            {
                SymmetricSecurityKey securityKey = null;
    
                lock (keySync)
                {
                    byte[] keyData = securityKeys.Where(k => k.KeyId == kid).Select(x => x.Key).FirstOrDefault();
    
                    if (keyData != null)
                    {
                        securityKey = new SymmetricSecurityKey(keyData);
                        securityKey.KeyId = kid;
                    }
                }
    
                return securityKey;
            }
    
            private static string fromBase64(string encodedValue)
            {
                byte[] decodedBytes = Convert.FromBase64String(encodedValue);
                return Encoding.UTF8.GetString(decodedBytes);
            }
        }
    }

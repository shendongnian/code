    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object ob, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
                {
                    return true;
                };
                using (var httpClient = new HttpClient(new NativeMessageHandler()))
                {
                    var tt = await httpClient.GetAsync(uri);
                    string tx = await tt.Content.ReadAsStringAsync();
                    //Log.Info(TAG, tx);
                }

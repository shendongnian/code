                    var handler = new NativeMessageHandler();
                    using (var client = new HttpClient(handler))
                    {
                        client.Timeout = TimeSpan.FromMilliseconds(ApiUrls.RemoteServerConnectorTestTimeout);
                        var removeString = "api.php";
                        var testHttp = DefaultServerUrl.EndsWith(removeString) ? DefaultServerUrl.Remove(DefaultServerUrl.Length - removeString.Length, removeString.Length) : DefaultServerUrl;
     
                        using (client.GetAsync(testHttp).Result)
                        {
                            return true;
                        }
    
                    }

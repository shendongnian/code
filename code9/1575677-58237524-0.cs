     var teamId = "YOURTEAMID";
     var keyId = "YOURKEYID";
                try
                {
                    //
                    var data = await System.IO.File.ReadAllTextAsync(Path.Combine(_environment.ContentRootPath, "apns/"+config.P8FileName));
                    var list = data.Split('\n').ToList();
                    var prk = list.Where((s, i) => i != 0 && i != list.Count - 1).Aggregate((agg, s) => agg + s);
                    //
                    var key = new ECDsaCng(CngKey.Import(Convert.FromBase64String(prk), CngKeyBlobFormat.Pkcs8PrivateBlob));
                    //
                    var token = CreateToken(key, keyId, teamId);
                    //
                    var deviceToken = "XXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                    var url = string.Format("https://api.sandbox.push.apple.com/3/device/{0}", deviceToken);
                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    //
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    //
                    request.Headers.TryAddWithoutValidation("apns-push-type", "alert"); // or background
                    request.Headers.TryAddWithoutValidation("apns-id", Guid.NewGuid().ToString("D"));
                    //Expiry
                    //
                    request.Headers.TryAddWithoutValidation("apns-expiration", Convert.ToString(0));
                    //Send imediately
                    request.Headers.TryAddWithoutValidation("apns-priority", Convert.ToString(10));
                    //App Bundle
                    request.Headers.TryAddWithoutValidation("apns-topic", "com.xx.yy");
                    //Category
                    request.Headers.TryAddWithoutValidation("apns-collapse-id", "test");
                    //
                    var body = JsonConvert.SerializeObject(new
                    {
                        aps = new
                        {
                            alert = new
                            {
                                title = "Test",
                                body = "Sample Test APNS",
                                time = DateTime.Now.ToString()
                            },
                            badge = 1,
                            sound = "default"
                        },
                        acme2 = new string[] { "bang", "whiz" }
                    })
                    //
                    request.Version = HttpVersion.Version20;
                    //
                    using (var stringContent = new StringContent(body, Encoding.UTF8, "application/json"))
                    {
                        //Set Body
                        request.Content = stringContent;
                        _logger.LogInformation(request.ToString());
                        //
                        var handler = new HttpClientHandler();
                        //
                        handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
                        //
                        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                        //Continue
                        using (HttpClient client = new HttpClient(handler))
                        {
                            //
                            HttpResponseMessage resp = await client.SendAsync(request).ContinueWith(responseTask =>
                            {
                                return responseTask.Result;
                                //
                            });
                            //
                            _logger.LogInformation(resp.ToString());
                            //
                            if (resp != null)
                            {
                                string apnsResponseString = await resp.Content.ReadAsStringAsync();
                                //
                                handler.Dispose();
                                //ALL GOOD ....
                                return;
                            }
                            //
                            handler.Dispose();
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    _logger.LogError(5, e.StackTrace, e);
                }

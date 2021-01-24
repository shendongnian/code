                    string uri = "yourdomain/api/controller/method;
    
                    var client = new HttpClient();
                    var values = new Dictionary<string, string>()
                        {
                            {"username", SecurityHelper.EncryptQueryString(username)},
                            {"password", SecurityHelper.EncryptQueryString(password)},
                        };
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync(uri, content);
                    response.EnsureSuccessStatusCode();

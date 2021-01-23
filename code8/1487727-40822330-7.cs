    string ResponseText= String.Empty();
    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://YOURAPI/");
                    
                        client.DefaultRequestHeaders.Accept.Clear();
                        //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue				    ("text/json"));
                        client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add("UserName", UserName);
                        client.DefaultRequestHeaders.Add("Password", Password);
                        // New code:
                        HttpResponseMessage response = await client.GetAsync		    ("api/YOURAPIENDPOINT").ConfigureAwait(continueOnCapturedContext: false);
                        if (response.IsSuccessStatusCode)
                        {
                            ResponseText = await response.Content.ReadAsStringAsync();
                        }
                    }

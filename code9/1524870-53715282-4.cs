    var someApiSettings = Configuration.GetSection("SomeApiSettings").Get<SomeApiSettings>(); //Settings stored in app.config (base url, api key to add to header for all requests)
    services.AddHttpClient<ISomeApiClient, SomeApiClient>("SomeApi",
                    client =>
                    {
                        client.BaseAddress = new Uri(someApiSettings.BaseAddress);
                        client.DefaultRequestHeaders.Add("api-key", someApiSettings.ApiKey);
                    });

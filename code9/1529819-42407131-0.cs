    private async void DoTestWebApi()
        {
            try
            {
                CookieContainer cookieContainer = new CookieContainer();
                HttpClientHandler handlerhttps = new HttpClientHandler
                {
                    UseCookies = true,
                    UseDefaultCredentials = true,
                    CookieContainer = cookieContainer
                };
                HttpClient clientPage = new HttpClient(handlerhttps)
                {
                    BaseAddress = new Uri("https://localhost:44356/user")
                };
                var pageWithToken = await clientPage.GetAsync(clientPage.BaseAddress);
                String verificationToken = GetVerificationToken(await pageWithToken.Content.ReadAsStringAsync());
                var cookies = cookieContainer.GetCookies(new Uri("https://localhost:44356/user"));
                using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer, UseDefaultCredentials = true, UseCookies = true })
                {
                    using (var client = new HttpClient(handler) { BaseAddress = new Uri("https://localhost:44356/user/test") })
                    {
                        var contentToSend = new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<string, string>("field", "value"),
                            new KeyValuePair<string, string>("__RequestVerificationToken", verificationToken),
                        });
                        var response = client.PostAsync(client.BaseAddress, contentToSend).Result;
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

     public static async Task MethodName()
        {
            using (HttpClientHandler handler = new HttpClientHandler() { UseCookies = false })
            {
                using (HttpClient httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Authorization = Program.getAuthenticationHeader();
                    string filterQuery = Program.getURI().ToString();
                    using (HttpResponseMessage httpResponse = await httpClient.GetAsync(filterQuery).ConfigureAwait(false))
                    {
                        var streamContent = await httpResponse.Content.ReadAsStreamAsync();
                        FileStream fs = new FileStream("C:\test\Stores.Json", FileMode.Create);
                        streamContent.CopyTo(fs);
                        streamContent.Close();
                        fs.Close();
                    }
                }
            }
        }

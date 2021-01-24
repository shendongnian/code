                public string LoginAsAdminAndRetrieveTicket(string userName, string passWord, string domain, string url)
        {
            var uri = $"http://{url}/otcs/llisapi.dll/api/v1/auth";
            var request = new HttpRequestMessage();
            request.Headers.Add("Connection", new[] { "Keep-Alive" });
            request.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            request.Headers.Add("Pragma", "no-cache");
            request.RequestUri = new Uri(uri);
            request.Method = HttpMethod.Post;
            request.Content = new StringContent($"username={userName};password={passWord}", Encoding.UTF8, "application/x-www-form-urlencoded");
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = WebRequest.GetSystemWebProxy(),
                UseProxy = true,
                AllowAutoRedirect = true
            };
            using (var client = new HttpClient(httpClientHandler))
            {
                var response = client.SendAsync(request).Result;
                string ticket;
                var vals = response.Headers.TryGetValues("OTCSTicket", out IEnumerable<string> temp) ? temp : new List<string>();
                if (vals.Any())
                {
                    ticket = vals.First();
                }
                return response.Content.ReadAsStringAsync().Result;
            }
        }

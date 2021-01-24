        public WrapperClass(Uri url, string username, string password, string proxyUrl = "")
        {
            if (url == null)
                // ReSharper disable once UseNameofExpression
                throw new ArgumentNullException("url");
            if (string.IsNullOrWhiteSpace(username))
                // ReSharper disable once UseNameofExpression
                throw new ArgumentNullException("username");
            if (string.IsNullOrWhiteSpace(password))
                // ReSharper disable once UseNameofExpression
                throw new ArgumentNullException("password");
            //or set your credentials in the HttpClientHandler
            var authenticationHeaderValue = new AuthenticationHeaderValue("Basic",
                // ReSharper disable once UseStringInterpolation
                Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username, password))));
            _httpClient = string.IsNullOrWhiteSpace(proxyUrl)
                ? new HttpClient
                {
                    DefaultRequestHeaders = { Authorization = authenticationHeaderValue },
                    BaseAddress = url
                }
                : new HttpClient(new HttpClientHandler
                {
                    UseProxy = true,
                    Proxy = new WebProxy
                    {
                        Address = new Uri(proxyUrl),
                        BypassProxyOnLocal = false,
                        UseDefaultCredentials = true
                    }
                })
                {
                    DefaultRequestHeaders = { Authorization = authenticationHeaderValue },
                    BaseAddress = url
                };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.AcceptEncoding.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Member> SomeCallToHttpClient(string organizationId)
        {
            var task = await _httpClient.GetStringAsync(<your relative url>));
            return JsonConvert.DeserializeObject<SomeType>(task,
                new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()});
        }

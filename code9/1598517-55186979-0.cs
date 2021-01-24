     static void Main(string[] args)
        {
            CreateWorkItem();
        }
        public static void CreateWorkItem()
        {
            string _tokenAccess = "************"; //Click in security and get Token and give full access https://azure.microsoft.com/en-us/services/devops/
            string type = "Bug";
            string organization = "type your organization";
            string proyect = "type your proyect";
            string _UrlServiceCreate = $"https://dev.azure.com/{organization}/{proyect}/_apis/wit/workitems/${type}?api-version=5.0";
            dynamic WorkItem = new List<dynamic>() {
                    new
                    {
                        op = "add",
                        path = "/fields/System.Title",
                        value = "Sample Bug test"
                    }
                };
            var WorkItemValue = new StringContent(JsonConvert.SerializeObject(WorkItem), Encoding.UTF8, "application/json-patch+json");
            var JsonResultWorkItemCreated = HttpPost(_UrlServiceCreate, _tokenAccess, WorkItemValue);
        }
        public static string HttpPost(string urlService, string token, StringContent postValue)
        {
            try
            {
                string request = string.Empty;
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", token))));
                    using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), urlService) { Content = postValue })
                    {
                        var httpResponseMessage = httpClient.SendAsync(httpRequestMessage).Result;
                        if (httpResponseMessage.IsSuccessStatusCode)
                            request = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    }
                }
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

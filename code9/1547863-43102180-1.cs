    protected PBIDashboards GetDashboards(string token)
        {
            PBIDashboards pbiDashboards = new PBIDashboards();
            var baseAddress = new Uri("https://api.powerbi.com");
            using (var httpClient = new System.Net.Http.HttpClient {BaseAddress = baseAddress})
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization",
                    "Bearer " + token);
                using (var response = httpClient.GetAsync("v1.0/myorg/dashboards").Result)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    //Deserialize JSON string
                    pbiDashboards = JsonConvert.DeserializeObject<PBIDashboards>(responseData);
                    if (pbiDashboards != null)
                    {
                        var gridViewDashboards = pbiDashboards.value.Select(dashboard => new
                        {
                            Id = dashboard.id,
                            DisplayName = dashboard.displayName,
                            EmbedUrl = dashboard.embedUrl
                        });
                    }
                }
            }
            return pbiDashboards;
        }

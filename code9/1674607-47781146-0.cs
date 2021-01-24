    using (var cl = new HttpClient())
            {
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.cloud-9-preview+json+scim"));
                cl.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "token");
                cl.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("curl", "7.46.0"));
                var val = cl.GetStringAsync("https://api.github.com/scim/v2/organizations/[ORG]/Users").Result;
            }

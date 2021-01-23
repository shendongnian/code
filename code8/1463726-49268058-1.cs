    public static async System.Threading.Tasks.Task<HttpResponseMessage> PostJsonAsync(object dataclass, string Url)
        {
            using (var client = new HttpClient())
                return await client.PostAsync(Url, new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(dataclass), System.Text.Encoding.UTF8, "application/json"));
        }

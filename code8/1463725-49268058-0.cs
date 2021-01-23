    public static StringContent AsJson(object o)
        {
            return new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(o), System.Text.Encoding.UTF8, "application/json");
        }
        public static async System.Threading.Tasks.Task<HttpResponseMessage> PostJson(object dataclass, string Url)
        {
            using (var client = new HttpClient())
                return await client.PostAsync(Url, AsJson(dataclass));
        }

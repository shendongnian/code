        public void Send(string auth, string filePath, string developerId)
        {
            string payload = System.IO.File.ReadAllText(filePath);
            var content = new StringContent(payload);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", auth);
                client.DefaultRequestHeaders.Add("Content-Type", "multipart/form-data");
                client.DefaultRequestHeaders.Add("Developer-Id", developerId);
                var result = client.PostAsync("https://api.knurld.io/v1/endpointAnalysis/file", content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
            }
        }

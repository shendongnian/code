        public void Send(string auth, string filePath, string developerId)
        {
            string payload = System.IO.File.ReadAllText(filePath);
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.Authorization] = auth;
                client.Headers[HttpRequestHeader.ContentType] = "multipart/form-data";
                client.Headers["Developer-Id"] = developerId;
                string response = client.UploadString("https://api.knurld.io/v1/endpointAnalysis/file", "POST", payload);
            }
        }

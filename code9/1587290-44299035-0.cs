     public class PostImageData
        {
            public int success { get; private set; }
        public async Task postData(string username, string password,string documentid, StreamContent streamContent)
        {
            UploadPhoto details = new UploadPhoto();
            try
            {
                System.Diagnostics.Debug.WriteLine("uplod done");
                var clinet = new HttpClient();
                var content = new MultipartFormDataContent();
                content.Add(streamContent, "file", "test.jpeg");
                System.Net.Http.HttpResponseMessage r =await clinet.PostAsync(YOUR_URL, content);                
                string json =await r.Content.ReadAsStringAsync();
                details = JsonConvert.DeserializeObject<UploadPhoto>(json);
                if (details.message == "Upload success")
                {
                    success = 200;
                }
                success = 200;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                success = 400;
            }
        }
        public class UploadPhoto
        {
            public string message { get; set; }
        }
    }

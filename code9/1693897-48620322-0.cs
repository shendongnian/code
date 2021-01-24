        private void Form1_Load(object sender, EventArgs e)
        {
            var nextPageUrl = "";
            WebRequest webRequest = null;
            if (webRequest == null && string.IsNullOrEmpty(nextPageUrl))
                webRequest = HttpWebRequest.Create(String.Format("https://api.instagram.com/v1/users/self/media/recent/?access_token=7030608823.1677ed0.f5877671841d4751af1de0c307b55d04"));
            else
                webRequest = HttpWebRequest.Create(nextPageUrl);
            var responseStream = webRequest.GetResponse().GetResponseStream();
            Encoding encode = System.Text.Encoding.Default;
            using (StreamReader reader = new StreamReader(responseStream, encode))
            {
                JToken token = JObject.Parse(reader.ReadToEnd());
                var pagination = token.SelectToken("pagination");
                if (pagination != null && pagination.SelectToken("next_url") != null)
                {
                    nextPageUrl = pagination.SelectToken("next_url").ToString();
                }
                else
                {
                    nextPageUrl = null;
                }
                var images = token.SelectToken("data").ToArray();
                int i = 0;
                foreach (var image in images)
                {
                    if (i < 10)
                    {
                        i++;
                        var imageUrl = image.SelectToken("images").SelectToken("standard_resolution").SelectToken("url").ToString();
                        WebClient client = new WebClient();
                        Directory.CreateDirectory(@"C:\instaPics\");
                        client.DownloadFile(imageUrl, @"C:\instaPics\instaPic" + i + ".jpg");

            string imgurID = "";
            string html = string.Empty;
            string url = @"https://api.imgur.com/3/gallery/r/nsfw/top/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers["Authorization"] = $"Client-ID {imgurID}";
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            try
            {
                dynamic json = JsonConvert.DeserializeObject(html);
                var index = new Random().Next(0, 100);
                ADebug.LogDebug(json.data[index].link); //Here is what i edited to fix the problem
            }
            catch(Exception e)
            {
                ADebug.LogCriticalError(e);
            }

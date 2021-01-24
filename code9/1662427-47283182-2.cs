            public static Stream DownloadImage(string url, string referer)
            {
                referer = Text.RemoveDiacritics(referer);
    
                Stream localStream = null;
                HttpWebResponse response = null;
    
                try
                {
                    var u = new Uri(url);
                    HttpWebRequest request;
    
                    request = (HttpWebRequest)WebRequest.Create(u);
    
                    request.Referer = referer;
                    request.UserAgent = SUserAgent;
    
                    response = (HttpWebResponse)request.GetResponse();
                    if (response != null)
                    {
                        return response.GetResponseStream();
                    }
                }
                catch (WebException wex)
                {
                    Logging.Write($"WEB ERROR {url} \n" + wex.Message);
                    throw;
                }
    
                return null;
            }
    
        public static void DownloadImage(string url, string referer, string localFilePath)
        {
            Stream stream = DownloadImage(url, referer);
            //byte[] fileBytes = GetBytesFromResponse(stream);
            FileStream file = File.Create(localFilePath);
            stream.CopyTo(file);
            //file.Write(fileBytes, 0, fileBytes.Length);
            file.Close();
        }

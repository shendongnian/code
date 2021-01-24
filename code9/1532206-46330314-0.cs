    private static async Task<string> GetLatestVersion(string URL)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(URL));
            request.ContentType = "application/json"; //i am using a json file 
            request.Method = "GET";
            request.Timeout = 20000;
            // Send the request to the server and wait for the response:
            try
            {
                using (WebResponse response = await request.GetResponseAsync())
                {
                    // Get a stream representation of the HTTP web response:
                    using (Stream stream = response.GetResponseStream())
                    {                    
                        StreamReader reader = new StreamReader(stream);
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

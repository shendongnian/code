    public async Task<string> GetFromUri(string uri)
        {
            var request = (HttpWebRequest) WebRequest.Create(new Uri(uri));
            request.ContentType = "application/json";
            request.Method = "GET";
            // Send the request to the server and wait for the response:  
            using (var response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:  
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream);
                    var message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                    return message;
                }
            }
        }

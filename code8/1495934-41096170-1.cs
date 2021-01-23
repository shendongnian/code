     public async Task<string> PostSample(object data, string uri)
        {
            // Create an HTTP web request using the URL:  
            var request = (HttpWebRequest) WebRequest.Create(new Uri(uri));
            request.ContentType = "application/json";
            request.Method = "POST";
            var itemToSend = JsonConvert.SerializeObject(data);
            using (var streamWriter = new StreamWriter(await request.GetRequestStreamAsync()))
            {
                streamWriter.Write(itemToSend);
                streamWriter.Flush();
                streamWriter.Dispose();
            }
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
 

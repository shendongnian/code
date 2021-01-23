       public async Task<string> PostTest(object sampleData, string uri)
        {
            var request = (HttpWebRequest) WebRequest.Create(new Uri(uri));
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Timeout = 4000; //ms
            var itemToSend = JsonConvert.SerializeObject(sampleData);
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
                    var message = reader.ReadToEnd();
                    return message;
                }
            }
        }

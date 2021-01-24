    var response = client.GetAsync("URL").Result;  // Blocking call!
    
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var dataObjects = response.Content.ReadAsAsync<object>().Result;
                 
                }
                else
                {
                    var result = $"{(int)response.StatusCode} ({response.ReasonPhrase})";
                   // logger.WriteEntry(result, EventLogEntryType.Error, 40);
                }

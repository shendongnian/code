      private async void RunClient(string _address, string username, string password)
        {
            // Create an HttpClient instance
            HttpClient client = new HttpClient();
            string authString = username + ":" + password;
   
            try
            {
                //add authentication to header
                var byteArray = Encoding.ASCII.GetBytes(authString);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                string valueString = "value";
                var con = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("relevance", valueString)
                });
                // Send a request asynchronously and continue when complete
                HttpResponseMessage response = await client.PostAsync(_address, con);
                // Check that response was successful or throw exception
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
               
            }
        }

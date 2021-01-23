      public async Task<T> GetWSObject<T>(string uriActionString)
        {
            var returnValue = default(T);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync(uriActionString);
                    response.EnsureSuccessStatusCode();
                    // this does not need a try catch, 
                    // because whatever exception is thrown here 
                    // will still be caught
                    returnValue = JsonConvert.DeserializeObject<T>(
                        response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception e)
            {
                // log or otherwise capture the exception details
                // if you don't need to log/capture the e variable
                returnValue.message1 = "A user-friendly description of the problem";
            }
            //catch // could also do it this way
            //{
            //    // if you don't need to log/capture the exception,
            //    // then don't bother with the overload
            //    returnValue.message1 = "A user-friendly description of the problem";
            //}
            return returnValue;
        }

    string urlParameters = "";
            //Your code goes here
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/geocode/xml?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA");
            // Add an Accept header for XML format.
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/xml"); //Keeps returning false
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            //Console.WriteLine(response);
             if (response.IsSuccessStatusCode)
                {
                   // output xml
                   string output = response.Content.ReadAsStringAsync().Result;
                 //response.Content.ReadAsStringAsync();
                 Console.WriteLine(output);
                }

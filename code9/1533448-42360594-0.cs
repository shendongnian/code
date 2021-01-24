     public async Task<int> InsertSales(IEnumerable<Models.SalesTable> newSales)
     {
         var ipAddress = "";// your IP address here
         var port = ""; // your port here
         var endpoint = $"http://{ipAddress}:{port}/insertsalesline";
         var requestString = JsonConvert.SerializeObject(newSales);
         var content = new StringContent(requestString, Encoding.UTF8, "application/json");
         using (var client = new HttpClient())
         {
             var reponse = await client.PostAsync(endpoint, content);
             if (reponse.IsSuccessStatusCode)
                 return 1;
             else
                 return 0;
         }
     }

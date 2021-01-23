        public HttpResponseMessage GetHttpResponse()
        {
           using (var client = new HttpClient())
           {
               return await client.SendAsync(new    
                 HttpRequestMessage()).ConfigureAwait(false).GetAwaiter().GetResult();
          }
        }

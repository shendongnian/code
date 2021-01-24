        public async Task<HttpResponseMessage> Download()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
        
            var stream = await GetStreamFromSomewhereMethod();
        
            var content = new StreamContent(stream, 4096); //buffer is 4KB
        
            response.Content = content;
            return response;
        }

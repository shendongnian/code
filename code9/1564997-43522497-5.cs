    public  class MessageHandler : DelegatingHandler
    {
        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            
            string requestInfo = string.Empty;
            
          
              
                requestInfo = string.Format("{0}:{1}", request.Method, request.RequestUri);
                var requestMessage = await request.Content.ReadAsByteArrayAsync();
                IncommingMessageAsync( requestInfo, requestMessage);
            
    
            var response = await base.SendAsync(request, cancellationToken);
            
                byte[] responseMessage;
    
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content != null)
                        responseMessage = await response.Content.ReadAsByteArrayAsync();
                    else
                        responseMessage = Encoding.UTF8.GetBytes(response.ReasonPhrase);
    
                }
                else
                    responseMessage = Encoding.UTF8.GetBytes(response.ReasonPhrase);          
                OutgoingMessageAsync( requestInfo, responseMessage);        
    
            return response;
        }
        protected void IncommingMessageAsync(string requestInfo, byte[] message)
        {
    
           var obj =JObject.Parse(Convert.ToString(message)); 
        }    
        protected void OutgoingMessageAsync( string requestInfo, byte[] message)
        {
            
        }
    }

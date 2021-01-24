    public static class Functions
    {
        [FunctionName("messages")]
        [return: Queue("somequeue")]
        public static async Task<MessagePayload> Messages([HttpTrigger
                (WebHookType = "genericJson")]HttpRequestMessage req) =>
            // return from this Azure Function immediately to avoid timeout warning message 
            // in the chat.
            // just put the request into "somequeue". 
            // We can't pass the whole request via the Queue, so pass only what we need for 
            // the message to be processed by Bot Framework
            new MessagePayload
            {
                RequestUri = req.RequestUri,
                Content = await req.Content.ReadAsStringAsync(),
                AuthScheme = req.Headers.Authorization.Scheme,
                AuthParameter = req.Headers.Authorization.Parameter
            };
    
        // Do the actual message processing in another Azure Function, which is 
        // triggered by a message enqueued in the Azure Queue "somequeue"
        [FunctionName("processTheMessage")]
        public static async Task ProcessTheMessage([QueueTrigger("somequeue")]
            MessagePayload payload, TraceWriter logger)
        {
            // we don't want the queue to process this message 5 times if it fails, 
            // so we won't throw any exceptions here at all, but we'll handle them properly.
            try
            {
                // recreate the request
                var request = new HttpRequestMessage
                {
                    Content = new StringContent(payload.Content),
                    RequestUri = payload.RequestUri
                };
                request.Headers.Authorization = new  
                    AuthenticationHeaderValue(payload.AuthScheme, payload.AuthParameter);
    
                // initialize dependency injection container, services, etc.
                var initializer = new SomeInitializer(logger);
                initializer.Initialize();
    
                // handle the request in a usual way and reply back to the chat
                await initializer.HandleRequestAsync(request);
            }
            catch (Exception ex)
            {
                try
                {
                    // TODO: handle the exception
                }
                catch (Exception anotherException)
                {
                    // swallow any exceptions in the exceptions handler?
                }
            }
        }
    
    }
    
    [Serializable]
    public class MessagePayload
    {
        public string Content { get; set; }
        public string AuthParameter { get; set; }
        public string AuthScheme { get; set; }
        public Uri RequestUri { get; set; }
    }

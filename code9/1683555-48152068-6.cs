        public PaymentResponseInternal Post(some stuff here)
        {
            Task<string> retornoPluginAsync = PostObjectToWebServiceAsJSON(some stuff here);
            retornoPluginAsync.ConfigureAwait(false); // Add this
            retornoPluginAsync.Wait();
            string result = retornoPluginAsync.Result;
    
            return JsonConvert.DeserializeObject<PaymentResponseInternal>(result);
        }

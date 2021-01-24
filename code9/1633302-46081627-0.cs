        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            await Task.Factory
                .StartNew(() => DoTheThing())
                .ContinueWith(tsk => { throw new Exception("Webhook Exception", tsk.Exception); }, TaskContinuationOptions.OnlyOnFaulted);
    
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

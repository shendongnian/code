        [HttpPost]
        public HttpResponseMessage Post()
        {
            var task = Task.Factory
                           .StartNew(() => DoTheThing())
                           .ContinueWith(tsk => { throw new Exception("Webhook Exception", tsk.Exception); }, TaskContinuationOptions.OnlyOnFaulted);
            task.Wait();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

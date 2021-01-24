        public string Get()
        {
            Task.Factory.StartNew(() =>
            {
                var task = DoSomething();
                task.Wait();
            }).Wait();
            Task.Factory.StartNew(async () =>
            {
                var task = DoSomething();
                await task;
            }).Unwrap().Wait();
            //task.ConfigureAwait(false).GetAwaiter().GetResult();
            return ControllerContext?.ToString();
        }

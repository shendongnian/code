       var ts = new CancellationTokenSource();
       CancellationToken ct = ts.Token;
    
        private void Start()
        {
           var task = Task.Factory.StartNew(() => {
             
             var client = new HttpClient();
             while(true)
             {
                if (ct.IsCancellationRequested)
                {
                   break;
                }
    
                string assetUrl = "https://api.example.com/blah?id=" + assetId;
                string response = await GetResponseText(client, assetUrl);
                dynamic assetJson = JsonConvert.DeserializeObject(response);
        
                if (assetJson != null)
                {
                   assetId++;
                }
             }
           }, ct).ContinueWith(ex => Console.WriteLine(ex.Message), TaskContinuationOptions.OnlyOnFaulted);
         }
         
    
         private void Stop()
         {
            ct.Cancel();
         }

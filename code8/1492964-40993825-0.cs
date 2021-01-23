    public async Task DoSomethingAndWaitAsync()
    {
       int i = 0;
       while (i < doc.GetElementsByTagName("ItemID").Count)
       {
           Task.Run(() => PerformHttpRequestMethod());
           if(i%2==0){
               await Task.Delay(TimeSpan.FromMinutes(2));
               //or simply: 
               await Task.Delay(120000);//120000 represents 2 minutes.
           }
           i++;
        }
    }

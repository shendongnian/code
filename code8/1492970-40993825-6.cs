    public async Task DoSomething()
    {
        for (int i = 0; i < doc.GetElementsByTagName("ItemID").Count; i=i+5)
        {
            if( i%10 == 0 ){
               for( int j=i;j<=i+4;j++){                   
                  Task.Run(() => PerformHttpRequestMethod());
               }
            }
            else{
               for(int j=i;j<=i+4;j++){
                  await Task.Delay(TimeSpan.FromMinutes(2));
               }
            }
        }
    }

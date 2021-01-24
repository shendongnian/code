    public void mainFunction() {
      //do stuff here
      var delayTime = 1.5;
      CancellationTokenSource source = new CancellationTokenSource();
      var t = Task.Run(async delegate
      {
         await Task.Delay(TimeSpan.FromSeconds(delayTime), source.Token);
         delayableFunction();
      });
    
      //can cancel here if necessary
      source.Cancel();
      //just continue on with other stuff... 
    }
    
    public void delayableFunction() {
      //do delay-able stuff here
    }

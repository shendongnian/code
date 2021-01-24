       public void StartListening() {
            
             _listener.Start();
             _logger.LogDebug("Http Listening started");
    
             Task.Run(() => {
                while(true) {
                  
                   if(_cancellationToken.IsCancellationRequested) return ;
    
                   try {
                      NonblockingListener();
                   }
                   catch (Exception e) {
                      _logger.LogError("Error With the listening Proccess, Message : "+e.Message);
                   }
                 
                }
             },_cancellationToken);
          }
    
    
          public void StopListening() {
    
             _cancellationTokenSource.Cancel();
             ListenerCallback(null);
    
             _logger.LogDebug("Http Listening Stop");
             _listener.Close();
          }
    
    
          public void NonblockingListener() {
             IAsyncResult result = _listener.BeginGetContext(ListenerCallback, _listener);
             result.AsyncWaitHandle.WaitOne();
          }
          public void ListenerCallback(IAsyncResult result) {
          
           if(_cancellationToken.IsCancellationRequested)return;
    
             _listener = (HttpListener)result.AsyncState;
    
         
             HttpListenerContext context = _listener.EndGetContext(result);
             HttpListenerRequest request = context.Request;
             
             //processing code
             EnqueUrl(request);
          }

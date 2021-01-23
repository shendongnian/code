    void List<HistoricalData> RequestData(Ticker ticker, TimeSpan timeout)
    {
        var socket= new Exchange(ticker);
        bool done=false;
        socket.OnData += _onData;
        socket.OnDone += _onDone;
        var request= NextRequestNr();
        var result = new List<HistoricalData>();
        var start= DateTime.Now;
        socket.RequestHistoricalData(requestId:request:days:1);
        try
        {
          while(!done)
          {   //stop when take to long….
            if((DateTime.Now-start)>timeout)
               break;
          }
          return result;
          
        }finally
        {
            socket.OnData-=_onData;
            socket.OnDone-= _onDone;
        }
    
    
       void _OnData(object sender, HistoricalData data)
       {
           _result.Add(data);
       }
       void _onDone(object sender, EndEventArgs args)
       {
          if(args.ReqId==request )
             done=true;
       } 
    }

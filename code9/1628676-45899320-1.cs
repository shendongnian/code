    bool shouldUpdate = false;
    ConcurrentQueue<WebSocketDataStructure> list = new ConcurrentQueue<WebSocketDataStructure>();
    Timer tim = new Timer();
    tim.AutoReset = true;
    tim.Interval = 1000;
    webSocket.OnMessage += (sender, e) =>
    {
        String websocketData = e.Data.Substring(3);
        list.enqueue(JsonConvert.DeserializeObject<WebSocketDataStructure>(websocketData));        
        shouldUpdate = true;     
        ;
    };
                
    tim.Elapsed += (s, e) =>
    {
        if (shouldUpdate)
        {
           shouldUpdate = false; Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                    new Action(() =>
                    {
                        while (list.Count > 0)
                           this.updateCanvas(list.Dequeue());                                                           
                    }));
        };
    };
    tim.Start();

    bool shouldUpdate = false;
    Queue<WebSocketDataStructure> list = new Queue<WebSocketDataStructure>();
    Timer tim = new Timer();
    tim.AutoReset = true;
    tim.Interval = 1000;
    webSocket.OnMessage += (sender, e) =>
    {
        String websocketData = e.Data.Substring(3);
        lock(list)
        {
            list.AddLast(JsonConvert.DeserializeObject<WebSocketDataStructure>(websocketData));
        }
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
                        lock(list)
                        {
                            while (list.Count > 0)
                                this.updateCanvas(list.Dequeue());
                        }
                                   
                    }));
        };
    };
    tim.Start();

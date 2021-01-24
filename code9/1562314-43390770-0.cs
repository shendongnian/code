    DispatcherOperation d = CameraList.Dispatcher.Invoke(DispatcherPriority.Normal, 
    new Action(() => { return CameraList.HasItems; }));
    var hasItems = Convert.ToBoolean(d.Value);
    if(!hasItems)
     //some logic

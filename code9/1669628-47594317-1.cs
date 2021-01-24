    System.Threading.Timer timer = null;
    timer = new System.Threading.Timer((obj) =>
    {
        ItemAddEventHandler();
        timer.Dispose();
    }, null, 3000, System.Threading.Timeout.Infinite);

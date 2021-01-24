    ZKFPEngX fp = new ZKFPEngX();
    fp.SensorIndex = 0;
    fp.InitEngine(); // Do validation as well as it returns an integer (0 for success, else error code 1-3)
    //subscribe to event for getting when user places his/her finger
    fp.OnImageReceived += new IZKFPEngXEvents_OnImageReceivedEventHandler(fp_OnImageReceived);

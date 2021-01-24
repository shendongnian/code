    Timer myTimer = new System.Windows.Forms.Timer();
    // Register the tick event handler
    myTimer.Tick += new EventHandler(TimerEventHandler);
    // Configure timer's tick interval (in ms)
    myTimer.Interval = 100;
    // Run the timer
    myTimer.Start();
    // Event handler
    private static void TimerEventHandler(Object myObject, EventArgs myEventArgs) 
    {      
            switch (connectionState) {
                case ConnectionState.AwaitPortSelected:
                    break;
                case ConnectionState.IsPortValid:
                    break;
                case ConnectionState.OpenPort:
                    break;
                case ConnectionState.AwaitLinkStateChange:
                    break;
                case ConnectionState.ClosePort:
                    break;
            }
       
    }

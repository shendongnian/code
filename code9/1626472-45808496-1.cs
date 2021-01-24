    void DoTheThing()
    {
        if(Dispatcher.CheckAccess())
        {
            // Do the thing, ie set up the video capture
        }
        else
        {
            Dispatcher.Invoke(DoTheThing);
        }
    }
        

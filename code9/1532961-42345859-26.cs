    public void MyCountMethod(int interval_msec, int start, int end)
    {
        System.Threading.Thread t = new System.Threading.Thread(() =>
        {
            for (int i = start; i <= end; i++)
            {
                // Check whether some other class has registered to the event
                if (CountEvent != null)
                {
                    // fire the event to transmit the counting data
                    CountEvent(i);
                    System.Threading.Thread.Sleep(interval_msec);
                }
            }
        });
        // start the thread
        t.Start();
    }

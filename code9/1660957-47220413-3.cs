    public void OnFrameSampleAcquired(VideoCaptureSample sample)
    {
        //Some code here
        //Here I want to introduce an Asynchrnous process
        ProcessAsynchronously(_latestImageBytes).ContinueWith(task => {
            // this runs after ProcessAsynchronously is completed
            // some more code here
        });
        // return without blocking
    }

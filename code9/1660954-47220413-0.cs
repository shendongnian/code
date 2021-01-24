    async Task ProcessAsynchronously(byte[] image)  
    {
        await Process1(image);
        await Process2(image);
        // ...
    }
    void OnFrameSampleAcquired(VideoCaptureSample sample)
    {  
        //Some code here
        //Here I want to introduce an Asynchrnous process
        ProcessAsynchronously(_latestImageBytes).Wait();
        //some more code here
    }

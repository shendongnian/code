    private static int _count = 0;
    ...
    // Wait until other images have finished processing
    while (_count >= 4)
    {
        Thread.Sleep(200);
    }
    try
    {
        Interlocked.Increment(ref _count);
        // Process it now
        Image template = Image.FromFile(MapPath("~/Content/Images/image.png");
        return ProccessImage(imageParams, template);    
    }
    finally
    {
        Interlocked.Decrement(ref _count);
    }

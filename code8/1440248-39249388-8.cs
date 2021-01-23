    bricks[i].LoadCompleted += onLoadComplete;
    bricks[i].LoadAsync(@"Images/brick_wall.jpg");
    ....
   
    private void onLoadComplete(Object sender, AsyncCompletedEventArgs e)
    {
        // Don't forget to check if the image has been really loaded,
        // this event fires also in case of errors.
        if (e.Error == null && !e.Cancelled)
            Console.WriteLine("Image loaded");
        else if (e.Cancelled)
            Console.WriteLine("Load cancelled");
        else
            Console.WriteLine("Error:" + e.Error.Message);
    }

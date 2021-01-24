    static void Main(string[] args)
    {
        VideoPlayer player = new VideoPlayer();
        WebPage page = new WebPage();
        player.EndOfVideo += page.VideoStopped;
        // Following method call on player object will call internally 
        // RaiseEndOfVideo  which will Raise event and event will execute 
        // VideoStopped method of page object which is attached in previous line 
        // and display "Video Stopped" message in Console.
        player.EndVideo();
        Console.WriteLine("Completed!!! Press any key to exit");
        Console.ReadKey();
    }

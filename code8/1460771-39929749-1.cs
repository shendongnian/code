    static void Main(string[] args)
    {
        // "Aww, it looks like something a child would ride!"
        var bike = new HondaBasic();
        bike.StartEngine();    
        // "Wow, is that in MPH or Km/h? Either way I could run faster than that!"
        var top = bike.GetTopSpeed();
    
        // "Well, lets take it for a spin, at least..."
        bike.StartEngine();
        var driven = bike.Drive(3, 30);
    }

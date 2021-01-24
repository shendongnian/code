    //auto-implemented property describing the location of your object
    public Point Location {get; set;}
    //"shortcut"/convenience properties that rely entirely on backing fields elsewhere, with no new memory of their own
    public int X 
    {
        get { return Location.X; }
        set { Location.X = value; }
    }
    public int Y
    {
        get { return Location.Y; }
        set { Location.Y = value; }
    }
    

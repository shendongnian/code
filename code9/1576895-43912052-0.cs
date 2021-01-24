    public static Page GetMapPage ()
    {   
        var map = new Map (MapSpan.FromCenterAndRadius (new Position (37, -122), Distance.FromMiles (10)));
        //If Label is not set, runtime exception
        var pin = new Pin () {
            Position = new Position (37, -122),
            Label = "Some Pin!"
        };
        map.Pins.Add (pin);
 
        var cp = new ContentPage { 
            Content = map, 
        };
        return cp;
    }

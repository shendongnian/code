    Array values = Enum.GetValues(typeof(EventColors));
    Random rnd = new Random();
    EventColors randomBar = (EventColors)values.GetValue(rnd.Next(values.Length));
    
    string name = Enum.GetName(typeof(EventColors), randomBar);
    var type = typeof(System.Drawing.Color);
    System.Drawing.Color systemDrawingColor = (System.Drawing.Color)type.GetProperty(name).GetValue(null);   

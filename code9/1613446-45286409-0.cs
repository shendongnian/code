    string red = "Red";
    string blue = "Blue";
    string yellow = "\n\n";
    string green = string.Empty;
    string black = null;
    var ColorList = new List<string>()
    {
        red,
        blue,
        yellow,
        green,
        black
    };
    //Red Blue
    string colors = string.Join(" ", 
        ColorList.Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => s.Trim())
    );

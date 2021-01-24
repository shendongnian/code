    string red = "Red";
    string blue = "Blue";
    string yellow = "\n\n";
    string green = string.Empty;
     List<string> ColorList = new List<string>()
    {
        red,
        blue,
        yellow,
        green
    };
    string colors = string.Join(" ", ColorList.Where(s => !string.IsNullOrEmpty(s)).Where(s => !s.Contains("\n")));

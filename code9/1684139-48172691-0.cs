    List<double> doubles = new List<double>();
    string[] lines = yourTextBox.Lines;
    foreach(string line in lines)
    {
        int lastSpaceIndex = line.LastIndexOf(' ');
        string doubleToken = line.Substring(++lastSpaceIndex);
        double d;
        if(double.TryParse(doubleToken, out d))
            double.Add(d);
    }

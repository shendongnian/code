    string planets = "First Mercury Gray"
                + Environment.NewLine
                + "Second Venus Yellow"
                + Environment.NewLine
                + "Third Earth Blue"
                + Environment.NewLine
                + "Fourth Mars Red"
                + Environment.NewLine;
    List<string> PlanetOrder = new List<string>();
    List<string> PlanetName = new List<string>();
    List<string> PlanetColor = new List<string>();
    string[] lines = planets.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
    foreach (string line in lines)
    {
        string[] arr = line.Split(' ');
        PlanetOrder.Add(arr[0]);
        PlanetName.Add(arr[1]);
        PlanetColor.Add(arr[2]);
    }

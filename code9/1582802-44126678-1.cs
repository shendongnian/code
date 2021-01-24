    string hostName = "B1";
    
    var buildings = new Dictionary<string, string> {
    	{ "B1", "Building 1" },
    	{ "B2", "Building 2" },
    	{ "B3", "Building 3" },
    	{ "B4", "Building 4" }
    };
    
    if (buildings.ContainsKey(hostName)) {
    	Console.Write(buildings[hostName]);
    }
    else {
    	Console.Write("Error!");
    }

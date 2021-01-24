    var dic = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
    	["G"] = "Good",
    	["Q"] = "Questionable",
    	["N"] = "NotCorrected",
    	["B"] = "BadEstimatedValue"
    };
    string input = "Q";
    if (Enum.TryParse<DataQuality>(dic[input], out var status))
    {
    	// Use "status" variable here
    	Console.WriteLine(status);
    }

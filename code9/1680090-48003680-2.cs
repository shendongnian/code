    var dic = new Dictionary<string, DataQuality>(StringComparer.OrdinalIgnoreCase)
    {
    	["G"] = DataQuality.Good,
    	["Q"] = DataQuality.Questionable,
    	["N"] = DataQuality.NotCorrected,
    	["B"] = DataQuality.BadEstimatedValue
    };
    string input = "Q";
    if (dic.TryGetValue(input, out var status))
    {
    	// Use "status" variable here
    }

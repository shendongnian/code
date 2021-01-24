	var packets = new Dictionary<string, double>[2, 3]
	{
		{ new Dictionary<string, double>(), new Dictionary<string, double>(), new Dictionary<string, double>(), },
		{ new Dictionary<string, double>(), new Dictionary<string, double>(), new Dictionary<string, double>(), },
	};
	
	packets[1, 0]["CO2"] = 2.6;
	packets[1, 1]["CO2"] = 2.4;
	packets[1, 2]["CO2"] = 2.9;

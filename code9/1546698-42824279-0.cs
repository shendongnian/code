	void Main()
	{
		var  temperatureDic = new Dictionary<int, double>()
		{
			{ 0, 1.10},{ 5, 1.06},{ 10, 1.03 },{ 15, 1.00 },{ 20, 0.97 },
			{ 25, 0.93 },{ 30, 0.89 },{ 35, 0.86 },{ 40, 0.82 },{ 45, 0.77 }
		};
		
		Debug.WriteLine(ReturnValue(temperatureDic, 8)); // 1.0461
	}
	
	public double ReturnValue(Dictionary<int, double> dict, int queryValue)
	{
        // Assuming dictionary Keys are x and Values are y
		var N = dict.Count;
		var sx = dict.Keys.Sum();
		var sxx = dict.Keys.Select(k => k*k).Sum();
		var sy = dict.Values.Sum();
		var sxy = dict.Select(item => item.Key * item.Value).Sum();
	
		var a = (N * sxy - sx * sy) / (N * sxx - sx * sx);
		var b = (sy - a * sx) / N;
	
		Debug.WriteLine($"a={a}, b={b}"); 
		
		// Now that we have a & b, we can calculate y = ax + b
		return a * queryValue + b;
	}

    public class World
    {
        public Dictionary<string, string> MyStrings = new Dictionary<string, string> ();
        public Dictionary<string, double> MyDoubles = new Dictionary<string, double> ();
        public string GetString(string key)
	    {
		    if (MyStrings.ContainsKey(key))
		    {
			    return MyStrings[key];
		    }
		    return "";
	    }
        public double GetDouble(string key)
	    {
		    if (MyDoubles.ContainsKey(key))
		    {
			    return MyDoubles[key];
		    }
		    return 0.0;
	    }
    }

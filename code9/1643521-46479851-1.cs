    public class World
    {
        public String abc {get;set;}
        public Dictionary<string, string> Animals = new Dictionary<string, string> ();
        public string GetAnimalString(string key)
	    {
		    if (Animals.ContainsKey(key))
		    {
			    return Animals[key];
		    }
		    return "";
	    }
    }

    public static int[] Locations 
    { 
        get 
        { 
            int[] values = Array.ConvertAll(Config.Read("locations", "ACCOUNT").Split(','), 
                s => int.Parse(s)) ?? new int[] { };
            return values; 
        } 
        set 
        { 
            Config.Write("locations", "ACCOUNT"); 
        } 
    }

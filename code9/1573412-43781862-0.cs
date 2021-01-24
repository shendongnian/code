    public static int[] Locations 
    { 
        get 
        { 
            int[] values
            return new int[] {Array.ConvertAll(Config.Read("locations", "ACCOUNT").Split(','), s => int.Parse(s)) ? new int[] { }}; 
        } 
        set 
        { 
            Config.Write("locations", "ACCOUNT"); 
        } 
    }

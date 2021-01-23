    string[] positionTypes = new String { "admin", "manager", "peon" }; //fill the array with your positions.
    public static int ConvertFromPosition(string pos)
    {
           return positionTypes.IndexOf(pos.ToLower().Trim());
    }
        

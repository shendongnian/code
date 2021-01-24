    public static int[] Locations
    {
        get
        {
            string locations = Config.Read("locations", "ACCOUNT");
            if (locations == null)
            {
                return new int[0];
            }
            return locations
                    .Split(',')         // split the locations separated by a comma
                    .Select(int.Parse)  // transform each string into the corresponding integer
                    .ToArray();         // put the resulting sequence (IEnumerable<int>) into an array of integers
        }
        set
        {
            Config.Write("locations", "ACCOUNT");
        }
    }

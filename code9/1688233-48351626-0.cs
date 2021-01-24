    public static class Entries
    {
        // ... all the other fields with static keyword
        public static string ColourLRB;
        public static string ColourW;
        public static Dictionary<string, bool> CheckBoxes { get; } = new Dictionary<string, bool>(); // no set, so you can only modify this. 
    }

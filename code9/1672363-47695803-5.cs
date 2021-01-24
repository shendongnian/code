    public static class Options
    {
        public static Option O1 = new Option()
        {
            aName = "A1",
            bName = "B1"
        };
    
        public static Option O2 = new Option()
        {
            aName = "A2",
            bName = "B2"
        };
    }
    private static IDictionary<string, Option> myOptionMap = new []
    {
        Options.O1, Options.O2
    }
    .ToDictionary(x => x.aName);

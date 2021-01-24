    public static class StringGenerators
    {
        public static StringDelegates.StringMethod FirstName = container => 
            Name.GetFirstName((string) container);
    }

    static class Questions
    {
        public static string[] contents = System.IO.File.ReadAllLines(@"TextFile/Questions.txt");
        public static Random newRandom = new Random();
        public static string questionToAsk = String.Empty // Will set it later
    }

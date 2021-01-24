    public static class Extensions
    {
        private static HashSet<char> mathOperators =
            new HashSet<char>(new[] { '+', '-', '=' }); // add more symbols here
        public static bool IsMathOperator(this char c) => mathOperators.Contains(c);
    }

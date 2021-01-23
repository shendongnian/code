    public static class ValidationSeries
        {
            private static Predicate<string>[] _checks = new Predicate<string>[]
            {
                    ValidationSeries.IsAtLeastFiveChars,
                    ValidationSeries.HasASpace,
                    ValidationSeries.HasNoLeadingSpace,
                    ValidationSeries.HasNoTrailingSpace
            };
    
            public static bool Check(string s, ICollection<string> failedPredicateNames)
            {
               
                var failed = false;
                foreach (var check in _checks)
                {
                    if ( !check(s) )
                    {
                        failedPredicateNames.Add(check.Method.Name);
                        failed = true;
                    }
                }
                return !failed;
            }
    
            public static bool IsAtLeastFiveChars(string text)
            {
                return text.Length >= 5;
            }
    
            public static bool HasASpace(string text)
            {
                return text.Contains(" ");
            }
    
            public static bool HasNoLeadingSpace(string text)
            {
                return !text.StartsWith(" ");
            }
    
            public static bool HasNoTrailingSpace(string text)
            {
                return !text.EndsWith(" ");
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var failures = new List<string>();
                if (!ValidationSeries.Check(" Hello World", failures))
                {
                    foreach (var f in failures)
                    {
                        Console.WriteLine(f);
                    }
                }
            }

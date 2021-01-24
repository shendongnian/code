    public static class StringExtensions
    {
        public static int ImaginaryIndexOf(this string str,IEnumerable<string> options)
        {
            return options.Select(x => str.IndexOf(x))
                .Where(x => x > -1).OrderBy(x => x)
                .DefaultIfEmpty(-1).FirstOrDefault();
        }
    }

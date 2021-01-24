    public static class StringExtensions
    {
        public static ValueTuple<string, string, string> Split(this string input, string delimiter)
        {
            var values = input.Split(new[] { delimiter }, StringSplitOptions.None);
            return ValueTuple.Create(values[0], values[1], values[2]);
        }
    }

    internal static IEnumerable<string> GetStrings(string input)
    {
        var values = "1234";
        var permutations = new List<string>();
         var index = input.IndexOf('@');
         if (index == -1) return new []{ input };
         for (int i = 0; i < values.Length; i++)
         {
             var newInput = input.Substring(0, index) + values[i] + input.Substring(index + 1);
             permutations.AddRange(GetStrings(newInput));
         }
         return permutations;
    }

     public static IEnumerable<int> GenerateNumbers(int length)
     {
         if (length < 1)
             throw new ArgumentOutOfRangeException(nameof(length));
         return generateNUmbers(ImmutableStack<string>.Empty,
                                Enumerable.Range(1, length - 1).Select(d => d.ToString(CultureInfo.InvariantCulture)),
                                length);
     }

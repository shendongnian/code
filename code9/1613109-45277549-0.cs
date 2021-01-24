    var sortedStrs = strings.OrderBy(s => s, new CollectionComparer<char>(CompareChar)).ToList();
    private static int CompareChar(char c1, char c2)
    {
        if (char.IsNumber(c1) || char.IsNumber(c2))
        {
            return c1 - c2;
        }
    
        var s1 = c1.ToString();
        var s2 = c2.ToString();
        var isLowerCaseS1 = s1 == s1.ToLower();
        var isLowerCaseS2 = s2 == s2.ToLower();
    
        if (isLowerCaseS1 && isLowerCaseS2 || !isLowerCaseS1 && !isLowerCaseS2)
        {
            return c1.CompareTo(c2);
        }
    
        return isLowerCaseS1 ? -1 : 1;
    }
    public class CollectionComparer<T> : IComparer<IEnumerable<T>>
    {
        private readonly Func<T, T, int> _comparisonFunc;
    
        public CollectionComparer(Func<T, T, int> comparisonFunc)
        {
            _comparisonFunc = comparisonFunc;
        }
    
        public int Compare(IEnumerable<T> c1, IEnumerable<T> c2)
        {
            //Ensure.Argument.NotNull(c1);
            //Ensure.Argument.NotNull(c2);
    
            var collection2 = c2?.ToList() ?? new List<T>();
            var collection1 = c1?.ToList() ?? new List<T>();
    
            var result = collection1.Select(
                (c, ind) => collection2.Count() > ind ? _comparisonFunc(c, collection2.ElementAt(ind)) : 1)
                .FirstOrDefault(e => e != 0);
    
            return result != 0 ? result : (collection2.Count > collection1.Count() ? -1 : 0);
        }
    }

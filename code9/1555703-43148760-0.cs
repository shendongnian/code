    public static class NaturalCompare
    {
        public static int Compare(string first, string second, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.Compare(first, second, comparison) == 0)
            {
                return 0;
            }
    
            if (first == null)
            {
                return -1;
            }
    
            if (second == null)
            {
                return 1;
            }
    
            DateTime d1, d2;
    
            if (DateTime.TryParse(first, out d1) && DateTime.TryParse(second, out d2))
            {
                return d1.CompareTo(d2);
            }
    
            var pos1 = 0;
            var pos2 = 0;
    
            int result;
            do
            {
                bool isNum1, isNum2;
    
                var part1 = GetNext(first, ref pos1, out isNum1);
                var part2 = GetNext(second, ref pos2, out isNum2);
    
                if (isNum1 && isNum2)
                {
                    result = long.Parse(part1).CompareTo(long.Parse(part2));
                }
                else
                {
                    result = String.Compare(part1, part2, comparison);
                }
            } while (result == 0 && pos1 < first.Length && pos2 < second.Length);
    
            return result;
        }
    
        public static int CompareToNatural(this string first, string second, StringComparison comparison = StringComparison.Ordinal)
        {
            return Compare(first, second, comparison);
        }
    
        public static IOrderedEnumerable<TSource> OrderByNatural<TSource>(this IEnumerable<TSource> source, Func<TSource, string> keySelector)
        {
            return source.OrderBy(keySelector, new NatComparer());
        }
    
        public static IOrderedEnumerable<TSource> OrderByNaturalDescending<TSource>(this IEnumerable<TSource> source, Func<TSource, string> keySelector)
        {
            return source.OrderByDescending(keySelector, new NatComparer());
        }
    
        private sealed class NatComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return NaturalCompare.Compare(x, y);
            }
        }
    
        private static string GetNext(string s, ref int index, out bool isNumber)
        {
            if (index >= s.Length)
            {
                isNumber = false;
                return "";
            }
    
            isNumber = char.IsDigit(s[index]);
    
            var start = index;
            while (index < s.Length && char.IsDigit(s[index]) == isNumber)
            {
                index++;
            }
            return s.Substring(start, index - start);
        }
    }

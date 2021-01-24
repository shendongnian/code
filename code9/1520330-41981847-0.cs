    searchStringList.Select(s => s.SubstringAsFarAsIndexOfAny(subStringList));
    public static class stringExt
    {
        public static int IndexOfAny(this string s, IEnumerable<string> anyOf, StringComparison stringComparisonType=StringComparison.CurrentCultureIgnoreCase) 
        {
        var best = anyOf
                    .Select(sub =>  s.IndexOf(sub, stringComparisonType))
                    .Aggregate(
                            int.MaxValue,
                            (bestSoFar, current) => 0 <= current && current < bestSoFar ? current : bestSoFar
                        );
        return best == int.MaxValue ? -1 : best;
        }
    
        public static string SubstringAsFarAsIndexOfAny(this string s, IEnumerable<string> anyOf, StringComparison stringComparisonType=StringComparison.CurrentCultureIgnoreCase)
        {
            var foundIndex= s.IndexOfAny(anyOf,stringComparisonType);
            return foundIndex >=0 ? s.Substring(0, foundIndex) : s;
        }
    }

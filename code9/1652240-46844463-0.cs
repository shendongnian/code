    public static class DapperHelper
        {
            private const string SingleTupleFormat = " [{0}] = '{1}' {2}";
            private const string AndString = "AND";
            private const string OrString = "OR";
    
            private static string ToSqlTuple(List<Dictionary<string, string>> filters) 
            {
                 string filterParam = string.Empty;
                 foreach (var filter in filters)
                 {
                     //Construct single tuple
                     string tuple = filter.ToList().Aggregate(string.Empty,
                     (current, pair) => current + String.Format(SingleTupleFormat, pair.Key, pair.Value, AndString));
    
                     //Concatenate tuples by OR
                     filterParam += string.Format(" ({0}) {1}}", tuple.TrimEnd(AndString), OrString);
                 }
                 return filterParam.TrimEnd(OrString);
             }
    
            public static string TrimEnd(this string source, string value)
            {
                if (!source.EndsWith(value))
                    return source;
    
                return source.Remove(source.LastIndexOf(value));
            }
        }

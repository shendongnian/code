    public static class StringExtensions
    {
        public static string[] Split(this String Source, string Separator)
        {
            if (String.IsNullOrEmpty(Source))
                throw new Exception("Source string is null or empty!");
            if (String.IsNullOrEmpty(Separator))
                throw new Exception("Separator string is null or empty!");
    
            char[] _separator = Separator.ToArray();
            int LastMatch = 0;
            List<string> Result = new List<string>();
    
    
            Func<char[], char[], bool> Matches = (source1, source2) =>
            {
                for (int i = 0; i < source1.Length; i++)
                {
                    if (source1[i] != source2[i])
                        return false;
                }
                return true;
            };
    
    
            for (int i = 0; _separator.Length + i < Source.Length; i++)
            {
                if (Matches(_separator.ToArray(), Source.Substring(i, _separator.Length).ToArray()))
                {
                    Result.Add(Source.Substring(LastMatch, i - LastMatch));
                    LastMatch = i + _separator.Length;
                }
            }
    
            Result.Add(Source.Substring(LastMatch, Source.Length - LastMatch));
            return Result.ToArray();
        }
    }

        public static string ReplaceWithNumberPrefix(this string source, string oldString, string newString, int numberPrefixStart)
        {
            var oldStringLength = oldString.Length;
            var indexes = new List<int>();
            var p = source.IndexOf(oldString);                    
            if (p >= 0)
                do
                {
                    indexes.Add(p);
                    p = source.IndexOf(oldString, p + 1);                    
                } while (p >= 0);
            var builder = new System.Text.StringBuilder(source);
            var trailingDifference = 0;
            for (int i = 0; i < indexes.Count; i++)
            {
                var replacement = string.Concat(newString, numberPrefixStart);
                var startIndex = indexes[i] + trailingDifference;
                builder.Replace(oldString, replacement, startIndex, oldStringLength);
                numberPrefixStart++;
                trailingDifference = trailingDifference + replacement.Length - oldStringLength;
            }
            return builder.ToString();
        }

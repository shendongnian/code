        public static string ReplaceWithNumberPrefix(this string source, string oldString, string newString, int numberPrefixStart)
        {
            var oldStringLength = oldString.Length;
            var indexes = new List<int>();
            int p = 0;
            while (p >= 0)
            {
                p = source.IndexOf(oldString, p + 1);
                if (p >= 0)
                    indexes.Add(p);
            }
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

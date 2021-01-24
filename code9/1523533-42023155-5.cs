    for (int i = 0; i < results.Length; i++)
    {
        results[i].enumValue = Enum.GetNames(results[i].enumType).Select(value =>
        {
            int cIteration = 0;
            while (cIteration < s.Length && cIteration + value.Length <= s.Length)
            {
                string toProcess = s.Substring(cIteration, value.ToString().Length);
                cIteration += value.ToString().Length + 1;
                try
                {
                    object valid = Enum.Parse(results[i].enumType, toProcess);
                    return valid;
                }
                catch { }
            }
            return null;
        })
        .FirstOrDefault(v => v != null);
    }

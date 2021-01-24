    for (int i = 0; i < results.Length; i++)
    {
        int cIteration = 0;
        results[i].enumValue = Enum.GetValues(results[i].enumType).OfType<object>().FirstOrDefault(value =>
        {
            string toProcess = s.Substring(cIteration, value.ToString().Length);
            cIteration += value.ToString().Length + 1;
            try
            {
                Enum.Parse(results[i].enumType, toProcess);
                return true;
            }
            catch { }
            return false;
        });
    }

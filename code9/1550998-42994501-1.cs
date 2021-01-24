    private static DynamicDictionary ToDynamicDictionary(IDictionary<int, int> dictionary)
        {
            DynamicDictionary result = new DynamicDictionary();
            foreach (var pair in dictionary)
            {
                result.Add(pair.Key.ToString(CultureInfo.InvariantCulture), pair.Value);
            }
            return result;
        }

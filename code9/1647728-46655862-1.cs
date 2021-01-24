    public static bool UpdateDictionaryAndGetOldValue(this Dictionary<string, string> dict, string key, string newVal, out string oldVal)
    {
        oldVal = string.Empty;
        if (dict.TryGetValue(key, out oldVal))
        {
            dict[key] = newVal;
            return true;
        }
        else
            return false;
    }

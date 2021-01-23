    private static bool Check2DictionariesAreEqual(Dictionary<string, object> entry1, Dictionary<string, object> entry2)
    {
        if(entry1 == null && entry2 == null)
        {
            return true;
        }
        else if(entry1 == null || entry2 == null)
        {
            return false;
        }
        if(entry1.Count != entry2.Count)
        {
            return false;
        }
        bool result = true;
        foreach (string key in entry1.Keys)
        {
            // Check Key
            result &= entry2.ContainsKey(key);
            if (!result) // Quick Break
            {
                break;
            }
            // Check Value
            result &= entry2[key] == entry1[key];
            if(!result) // Quick Break
            {
                break;
            }
        }
        return result;
    }

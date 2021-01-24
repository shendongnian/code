    private static void LoadDictionary()
    {
        int i = 0;
        foreach (var ss in sharedStringTablePart.SharedStringTable.ChildElements)
        {
            dictionary.Add(i++, ss.InnerText);
        }
    }

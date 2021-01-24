     public static void Add2Dic(IDictionary firstDict, IDictionary secondDict, bool bReplaceIfExists)
        {
            foreach (object key in firstDict.Keys)
            {
                if (!secondDict.Contains(key))
                    secondDict.Add(key, firstDict[key]);
                else if (bReplaceIfExists)
                    secondDict[key] = firstDict[key];
            }
        }

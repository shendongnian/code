            DictionaryEntry [] DictionaryStringInt
            {
                get
                {
                    if (dictionaryStringInt == null)
                        return null;
                    List<DictionaryEntry> list = new List<DictionaryEntry>();
                    foreach (KeyValuePair<string, int> element in dictionaryStringInt)
                    {
                        list.Add(new DictionaryEntry(element.Key, element.Value));
                    }
                    return list.ToArray();
                }
                set
                {
                    if (value == null)
                        return;
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    foreach (DictionaryEntry entry in value)
                    {
                        dictionary.Add(entry.Key, entry.Value);
                    }
                    dictionaryStringInt = dictionary;
                }
            }

    private static void AddWordsInDictionary(string phrase, ref Dictionary<string, string> dctKeywords)
    {
 
        var keyWords = phrase.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Trim() != string.Empty).ToList();
 
        Dictionary<string, string> dct = new Dictionary<string ,string>();
        int id = 0;
 
        string newPhrase = "";
        foreach (var keyword in keyWords)
        {
            dct[id.ToString()] = keyword;
            newPhrase = newPhrase + id.ToString();
            id++;
        }
 
        int xx = 0;
 
        while (xx < newPhrase.Length)
        {
            for (int idx = 0; idx <= newPhrase.Length; idx++)
            {
                if ( idx - xx > 0)
                {
                    var item = newPhrase.Substring(xx, idx - xx).ToString();
                    StringBuilder sb = new StringBuilder();
                    foreach (var itm in item)
                    {
                        sb.Append(dct[itm.ToString()] + " ");
                    }
                    var key = sb.ToString().Trim();
                    dctKeywords[key] = key;
                }
            }
            xx++;
        }
 
    }

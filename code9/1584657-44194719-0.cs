    var dicts = new[]{"A", "B", ......., "T"}
    foreach (var dict in dicts)
    {
        var found = CheckDictionary(theDictionary, $"theDictionary.{dict}");
        if (found != null)
        {
            Dictionary_Find(Account_String, rowindex, found, Cash_Value, txtCurrency.Text);
            break;
        }
    }
    public static Dictionary<int, DictionarySetup> CheckDictionary(Dictionary<int, DictionarySetup> AccountLexicon, string dictName)
    {
       var theDictionary = AccountLexicon.GetType().GetProperty(dictName).GetValue(AccountLexicon, null);
        return Dictionary_Test(theDictionary) ? theDictionary : null;
    }

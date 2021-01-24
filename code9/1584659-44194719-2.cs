    var dicts = new[]{"A", "B", ......., "T"}
    foreach (var dict in dicts)
    {
        var found = CheckDictionary(theDictionary, dict);
        if (found != null)
        {
            Dictionary_Find(Account_String, rowindex, (Dictionary<int, DictionarySetup>)found, Cash_Value, txtCurrency.Text);
            break;
        }
    }
    public static object CheckDictionary(object dictClass, string dictName)
    {
       var theDictionary = dictClass.GetType().GetProperty(dictName).GetValue(dictClass, null);
        return Dictionary_Test(theDictionary) ? theDictionary : null;
    }

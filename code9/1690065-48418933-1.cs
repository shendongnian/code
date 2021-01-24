    var mkDBDictionary = mkDB.Selections.ToDictionary(s => RegexReplace(s.Name, @"\([\d.]+\)"), s => s);
    foreach (var selTPL in mkTPL.Selections)
    {   
        string selTPLName = RegexReplace(selTPL.Name, @"\([\d.]+\)");
        if (mkDBDictionary.TryGetValue(selTPLName, out var selDB))
        {
            selTPL.OddOrResultValue = selDB.OddOrResultValue;
        }
    }

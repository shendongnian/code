    var mainList = new List<string> { "Reset", "Set", "Test", "Test", "Reset", "Test", "Test" };
    Dictionary<int, List<string>> resultList = new Dictionary<int, List<string>>();
    int DictionaryIndex = 0;
    foreach (string item in mainList)
    {
        if (item == "Reset")
        {
            resultList.Add(++DictionaryIndex, new List<string>() { item });
        }
        else
        {
            resultList[DictionaryIndex].Add(item);
        }
    }

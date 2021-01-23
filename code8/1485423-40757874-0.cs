    var AssembliesGlobal = new Dictionary<string, List<string>>();
    AssembliesGlobal.Add("Steve", new List<string> { "1", "2", "3"});
    foreach (var key in AssembliesGlobal.Keys)
    {
        AssembliesGlobal[key].Add("4");
    }

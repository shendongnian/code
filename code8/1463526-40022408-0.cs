    var mappings = new Dictionarx<string, string> { { "1734-IB8S", "m1734IB8S" }, { "1734-OB8S", "m1734OB8S" } /* ... */ }
    var resourceManager = new ResourceManager("yourresourcefilename", typeof(Cards).Assembly);
    while (moduleList.Any() && !moduleList[0].name.Contains("AENTR") && !moduleList[0].name.Contains("1756"))
    {
        string resourceName;
        if (!mappings.TryGetValue(moduleList[0].name, out resourceName))
        {
            continue;
        }
        var field = resourceManager.GetString(resourceName);
        string newCard = field.Replace("@SLOT@", modSlotCount.ToString());
        newCard = newCard.Replace("@AENTRNUM@", aentrCount.ToString());
        finalOutput = finalOutput + newCard;
        finalOutput += Environment.NewLine;
        finalOutput += Environment.NewLine;
        moduleList.RemoveAt(0);
        modSlotCount++;
    }

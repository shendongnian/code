    var outDict = new List<Item>();
    switch(name) {
        case "simpleDict":
            IList<Item> simpleDict = _dataLayer.GetSimpleDict();
            // ...
            outDict.AddRange(simpleDict);
            break;
        case "extDict":
            IList<ExtendedItem> extDict = _dataLayer.GetExtDict();
            // ...
            outDict.AddRange(extDict);
            break;
        // ... and a few more dictionaries
    }

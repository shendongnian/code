    dynamic termsTable = new DynamicDictionary();
    var name = "name";
    int commodityId = 123;
    var year = DateTime.Now.Year + 5;
    // need to check if such key exists
    // like isset in php
    if (termsTable[name] == null)
        termsTable[name] = new DynamicDictionary();
    if (termsTable[name][commodityId] == null)
        termsTable[name][commodityId] = new DynamicDictionary();
    for (int y = 2008; y <= year; y++) {
        if (termsTable[name][commodityId][y] == null)
            termsTable[name][commodityId][y] = new DynamicDictionary();
        for (int i = 1; i < 12; i++) {
            // that's fine
            termsTable[name][commodityId][y][i] = 0;
        }
    }

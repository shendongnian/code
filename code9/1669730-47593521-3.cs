    dynamic termsTable = new DynamicDictionary();
    var name = "name";
    int commodityId = 123;
    var year = DateTime.Now.Year + 5;
    for (int y = 2008; y <= year; y++) {
        for (int i = 1; i < 12; i++) {
            // that's fine
            termsTable[name][commodityId][y][i] = 0;
        }
    }
    // let's see what we've got:
    for (int y = 2008; y <= year; y++) {
        for (int i = 1; i < 12; i++) {
            // that's fine
            Console.WriteLine(termsTable[name][commodityId][y][i]);
        }
    }

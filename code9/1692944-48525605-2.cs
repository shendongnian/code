    private static dynamic GetDataWithName(TestName testNames, string name)
    {
        return testNames.TestItems.Where(ex => ex.TestNamesId == testNames.TestId && ex.TestItemName == name)
        .Select(r => new
        {
            r.TestItemId,
            r.TestItemName,
            r.TestItemDirectory
        }).FirstOrDefault();    
    }
    public Foo GetInfo(TestName testNames)
    {
        int testNameId = testNames.TestId;
        Foo foo = new Foo();
        switch (testNameId)
        {
             case 3:
                  var passRecord = GetDataWithName(testNames, "PASS");
              foo.PassChoiseInfo = $"{passRecord.TestItemId},{passRecord.TestItemName},{passRecord.TestItemDirectory}";
              var failRecord = GetDataWithName(testNames, "FAIL");
               foo.FailChoiceInfo = $"{failRecord.TestItemId},{failRecord.TestItemName},{failRecord.TestItemDirectory}";
               var naRecord = GetDataWithName(testNames, "N/A");
     
                foo.NAChoiceInfo = $"{naRecord.TestItemId},{naRecord.TestItemName},{naRecord.TestItemDirectory}";
                     break;
                 case 4:
                     break;
                 case 5:
                     break;
                 case 7:
                     break;
     
                     //6 more cases
             }
             return foo;
         }
     }

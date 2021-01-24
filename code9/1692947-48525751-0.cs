    public Foo GetInfo(TestName testNames)
    {
       string GetItemDescriptionShortcut(string testItemName)
       {
          return this.GetItemDescription(testNames, testItemName);
       }
    
       Foo foo = new Foo
       {
          PassChoiseInfo = GetItemDescriptionShortcut("Pass"),
          FailChoiceInfo = GetItemDescriptionShortcut("Fail"),
          NAChoiceInfo = GetItemDescriptionShortcut("N/A")
       }
    
       return foo;
    
    }
    
    private string GetItemDescription (TestName testNames, string testItemName)
    {
        var item = testNames.TestItems
            .Where(ex => ex.TestNamesId == testNames.TestId && ex.TestItemName == testItemName)
            .Select(r => new
            {
              r.TestItemId,
              r.TestItemName,
              r.TestItemDirectory
            }).FirstOrDefault();
    
        if (item == null) return null; // or empty string
    
        return $"{item.TestItemId},{item.TestItemName},{item.TestItemDirectory}";
    }

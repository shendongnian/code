    public Foo GetInfo(TestName testNames)
    {
        int testNameId = testNames.TestId;
        Foo foo = new Foo();
            Func<TestItem, dynamic> dynamicBuilder = r => new { r.TestItemId, r.TestItemName, r.TestItemDirectory };
            Func<string, int, TestItem> filteringMethod = (name, nameId) => testNames.TestItems.Where(ex => ex.TestNamesId == nameId && ex.TestItemName == name).Select(dynamicBuilder).FirstOrDefault();
            Func<TestItem, string> formatMethod = record => $"{record.TestItemId},{record.TestItemName},{record.TestItemDirectory}";
            switch (testNameId)
            {
                case 3:
                    foo.PassChoiseInfo = formatMethod(filteringMethod("Pass", 3));
                    foo.FailChoiceInfo = formatMethod(filteringMethod("Fail", 3));
                    foo.NAChoiceInfo = formatMethod(filteringMethod("N/A", 3));
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

    [Test, TestCaseSource(typeof(string), nameof(SomeClass.someCases))]
    public void Test(string someValue)
    {
       Console.WriteLine(someValue);
    }
    private class someClass
    {
       public static IEnumerable someCases
       {
           get
           {
              yield return
                 new TestCaseData("valuefornow");
              yield return
                 new TestCaseData("valueforlater");
           }
        }
    }

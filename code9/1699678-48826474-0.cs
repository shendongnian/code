    public class TestCase
    {
        public string title;
        public TestCase(string Title)
        {
            title = Title;
        }
        public Action dummyMethod{ get; set; }
    }
    public void realMethod()
    {
        System.Console.WriteLine("testSuccesfull");
    }
    public initTestcollection()
    {
        AddTestCases();
        T1.TestcaseList[0].dummyMethod= realMethod;
    }

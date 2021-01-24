    File testDLLPath = File("./test.dll");
    var tester = new Tester(testDLLPath);
    tester.RunTests();
    public class Tester
    {
       public FilePath TestDLLPath { get; set; }       
       public void RunTests()
       {
           //Do Stuff accessing class property TestDLLPath
       }
       public Tester(FilePath path)
       {
            TestDLLPath = path;
       }
    }

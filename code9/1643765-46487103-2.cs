    BuildParams.TestDLLPath  = File("./test.dll");
    RunTests();
    public static void RunTests()
    {
        // do stuff with BuildParams.TestDLLPath
    }
    public static class BuildParams
    {
       public static FilePath TestDLLPath { get; set; }    
    }

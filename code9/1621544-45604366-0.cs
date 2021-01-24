    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [TestClass]
    public class AssemblyInitUnitTest
    {
        static FileStream objStream;
    
        [AssemblyInitialize()]
        public static void Setup(TestContext testContext)
        {
            objStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\AAA_UnitTestPerfMonitor.txt", FileMode.OpenOrCreate);
            TextWriterTraceListener objTraceListener = new TextWriterTraceListener(objStream);
            Trace.Listeners.Add(objTraceListener);
            Trace.WriteLine("===================================");
            Trace.WriteLine("App Start:" + DateTime.Now);
            Trace.WriteLine("===================================");    
        }
    
        [AssemblyCleanup]
        public static void TearDown()
        {
            Trace.Flush();
            objStream.Close();
        }
    }

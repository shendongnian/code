    using NUnit.Framework;
    using ConsoleApplication1;
    using System.IO;
    using System.Diagnostics;
    
    [TestFixture]
    public class UnitTest1
    {    
        static FileStream objStream;
    
        [SetUp]
        public static void Setup()
        {
            objStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\AAA_Output.txt", FileMode.OpenOrCreate);
            TextWriterTraceListener objTraceListener = new TextWriterTraceListener(objStream);
            Trace.Listeners.Add(objTraceListener);
            Trace.WriteLine("===================================");
            Trace.WriteLine("App Start:" + DateTime.Now);
            Trace.WriteLine("===================================");
        }
            
        [TestCase]
        public void TestMethod1()
        {
            Program.CreateDB();
        }
    
        [TearDown]
        public static void TearDown()
        {
            Trace.Flush();
            objStream.Close();
        }
    }

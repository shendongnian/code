        public interface ISampleInterface
    {
        void Run();
    }
    public class SampleClass : ISampleInterface
    {
        public void Run()
        {
            // your business Logic Here.
        }
    }
    public class Test
    {
        private ISampleInterface _sampleinterface;
        public Test(ISampleInterface sampleinterface)
        {
            _sampleinterface = sampleinterface;
        }
        public void TestMethod()
        {
            _sampleinterface.Run();
        }
    }

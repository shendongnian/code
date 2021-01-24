    public interface IWriter
    {
        void WriteLine(string str);
    }
    
    public class BaseTest : IWriter
    {
        public ITestOutputHelper Output { get; }
        public BaseTest(ITestOutputHelper output)
        {
            Output = output;
        }
        public void WriteLine(string str)
        {
            Output.WriteLine(str ?? Environment.NewLine);
        }
    }

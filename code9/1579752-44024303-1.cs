    public class BaseTestClass
    {
        protected ITestOutputHelper Output { get; }
        public BaseTestClass(ITestOutputHelper output)
        {
            Output = output;
        }
        public void WriteLine(string str)
        {
            Output.WriteLine(str ?? Environment.NewLine);
        }
    }
    
    public class MyTestClass : BaseTestClass
    {
        public MyTestClass(ITestOutputHelper output) : base(output) {}
        [Fact]
        public void MyTest()
        {
            WriteLine("foo");
        }
    }

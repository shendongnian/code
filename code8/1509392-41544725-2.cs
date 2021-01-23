    public sealed class MyClass
    {
        readonly Action<string> _writeLogLine;
        public MyClass(Action<string> writeLogLine)
        {
            _writeLogLine = writeLogLine;
        }
        public void Test()
        {
            _writeLogLine("Test() called");
        }
    }

    public abstract class TestOutput : IOutput
    {
        public TestOutput()
        {
            Outputs = new List<string>();
        }
        public void Read()
        {
            //do nothing?
        }
        public abstract string ReadLine();
        public void WriteLine(string text)
        {
            Outputs.Add(text);
        }
        public List<string> Outputs { get; set; }
    }
    public class TestOutputWithAValidNumber : TestOutput
    {
        public TestOutputWithAValidNumber(int value)
        {
            Value = value;
        }
        public override string ReadLine()
        {
            return Value.ToString();
        }
        public int Value { get; }
    }
    public class TestOutputWithNotValidNumber : TestOutput
    {
        public TestOutputWithNotValidNumber(string value)
        {
            Value = value;
        }
        public override string ReadLine()
        {
            return Value;
        }
        public string Value { get; }
    }

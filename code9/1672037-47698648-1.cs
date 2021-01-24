    public class MyBinding : Binding
    {
        public MyBinding(string path) : base(path)
        {
        }
        private int _intvalue = 0;
        public int IntValue { get => _intvalue; set { _intvalue = value; } }
        private string _stringvalue = null;
        public string StringValue { get => _stringvalue; set { _stringvalue = value; } }
    }

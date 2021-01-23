    delegate int SomeDelegate(int i);
    public class Delegates
    {
        public SomeDelegate Delegate { get; set; }
        public Delegates(SomeDelegate _delegate)
        {
            Delegate = _delegate;
        }
        public int InvokeDelegate(int i)
        {
            return Delegate(i);
        }
    }

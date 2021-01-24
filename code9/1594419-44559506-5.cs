    public class ClassB
    {
        // Can be readonly if it is assigned only ever once, in the ctor.
        private readonly Action _action;
        public ClassB(Action action)
        {
            Contract.Assert(action != null);
            _action = action;
        }
        public void ButtonClick()
        {
            _action(); // i.e. no need for Invoke or null check.
        }
    }

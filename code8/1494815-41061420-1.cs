    public class Foo
    {
        int    _memberVariable;
        readonly Action _onEventOne;
        readonly Action _onEventTwo;
    
        public Foo(Action onEventOne): this(onEventOne, null) { }
        public Foo(Action onEventOne, Action onEventTwo)
        {
            _memberVariable = 0;
    
            _onEventOne = onEventOne;
            _onEventTwo = onEventTwo ?? DefaultEventTwo;
    
            _onEventOne();
        }
    
        private void DefaultEventTwo()
        {
            ++_memberVariable;
        }
    }

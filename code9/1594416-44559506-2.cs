    public class ClassB
    {
        private Action<int> _action;
        public void SetMethod(Action<int> action)
        {
            _action = action;
        }
        public void ButtonClick()
        {
            var n = 2;
            _action.Invoke(n);
        }
    }

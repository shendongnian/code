    class Test {
        private Action MyEvent;
        public event Action MyEvent
        {
            add { Delegate.Combine(this.MyEvent, (Delegate) value);}
            remove { Delegate.Remove(this.MyEvent, value); }
        }
    }

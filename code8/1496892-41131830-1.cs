    public class MyClass
    {
        private readonly WeakCollection<EventHandler<FooEventArgs>> _foo = new WeakCollection<EventHandler<FooEventArgs>>();
    
        public event EventHandler<FooEventArgs> Foo
        {
            add
            {
                lock (_foo)
                {
                    _foo.Add(value);
                }
            }
            remove
            {
                lock (_foo)
                {
                    _foo.Remove(value);
                }
            }
        }
    
        protected virtual void OnFoo(FooEventArgs args)
        {
            lock (_foo)
            {
                foreach (var foo in _foo.GetLiveItems())
                {
                    foo(this, args);
                }
            }
        }
    }

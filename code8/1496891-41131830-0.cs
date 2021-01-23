    public class MyClass
    {
        private readonly WeakCollection<EventHandler<FooEventArgs>> _foo = new WeakCollection<EventHandler<FooEventArgs>>();
        private readonly object _syncObject = new object();
    
        public event EventHandler<FooEventArgs> Foo
        {
            add
            {
                lock (_syncObject)
                {
                    _foo.Add(value);
                }
            }
            remove
            {
                lock (_syncObject)
                {
                    _foo.Remove(value);
                }
            }
        }
    
        protected virtual void OnFoo(FooEventArgs args)
        {
            lock (_syncObject)
            {
                foreach (var foo in _foo.GetLiveItems())
                {
                    foo(this, args);
                }
            }
        }
    }

    class Program
    {
        class Item
        {
            public int SomeProperty { get; }
    
            public Item(int prop)
            {
                SomeProperty = prop;
            }
        }
    
        class MockEnumerator
        {
            private Item[] _items = new Item[] { new Item(1), new Item(2) };
            private int _position = 0;
    
            public bool Next()
            {
                return _position++ < _items.Length;
            }
    
            public Item Read()
            {
                return _items[_position];
            }
        }
    
        class EnumeratorWrapper : IEnumerator<Item>, IEnumerable<Item>
        {
            private readonly MockEnumerator _enumerator;
    
            public EnumeratorWrapper(MockEnumerator enumerator)
            {
                this._enumerator = enumerator;
            }
    
            public Item Current => _enumerator.Read();
    
            object IEnumerator.Current => Current;
    
            public void Dispose()
            {
            }
    
            public IEnumerator<Item> GetEnumerator()
            {
                throw new NotImplementedException();
            }
    
            public bool MoveNext()
            {
                return _enumerator.Next();
            }
    
            public void Reset()
            {
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this;
            }
        }
    
        private static List<Item> _list = new List<Item>();
    
        static void Main(string[] args)
        {
            var enumerator = new EnumeratorWrapper(new MockEnumerator());
            Parallel.ForEach(enumerator, item =>
            {
                if (item.SomeProperty == 1)//someval
                {
                    lock (_list)
                    {
                        _list.Add(item);
                    }
                }
            });
        }
    }

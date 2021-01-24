    public class MyClass
    {
        public MyClass(string name, IEnumerable<MyNodeClass> nodes)
        {
            //...
        }
    }
    
    public class MyNodeClass
    {
        public MyNodeClass(int id)
        {
            //...
        }
    }
    
    public class MyNodes : IEnumerable<MyNodeClass>
    {
        private readonly IEnumerable<int> _data;
        public MyNodesClass(IEnumerable<int> data)
        {
            _data = data;
        }
    
        public IEnumerator<MyNodeClass> GetEnumerator()
        {
            foreach (var id in _data)
            {
                yield return new MyNodeClass(id);
            }
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

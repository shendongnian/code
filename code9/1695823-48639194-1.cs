    public sealed class EmptyLookup<T, K> : ILookup<T, K> 
    {
            private static readonly EmptyLookup<T, K> _instance 
                = new EmptyLookup<T, K>();
    
            public static EmptyLookup<T, K> Instance
            {
                get { return _instance; }
            }
    
            private EmptyLookup() { }
    
            public bool Contains(T key)
            {
                return false;
            }
    
            public int Count
            {
                get { return 0; }
            }
    
            public IEnumerable<K> this[T key]
            {
                get { return Enumerable.Empty<K>(); }
            }
    
            public IEnumerator<IGrouping<T, K>> GetEnumerator()
            {
                yield break;
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                yield break;
            }
        }
    then you can write code like this:
    
    var x = EmptyLookup<int, int>.Instance;
    /*The benefit of creating a new class is that you can use the "is" operator and check for type equality:*/
    
    if (x is EmptyLookup<,>) {
     // ....
    }

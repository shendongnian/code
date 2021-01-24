    public class E
    {
        public bool MoveNext() { return true; }
        public object Current { get { return null; } }
    }
    public class C
    {
        public E GetEnumerator()
        {
            return new E();
        }
    }

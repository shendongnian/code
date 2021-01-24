    namespace TestApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                int test0 = new A().GetInt();
                int test1 = new IndexedUno()[2];
                int test2 = new IndexedDo()[2];
            }
        }
    
        public interface IIndexed
        {
            int this[int i] { get; }
        }
    
    
        public class IndexedUno : IIndexed
        {
            public int this[int i] => i;
        }
    
        public class IndexedDo : IIndexed
        {
            public int this[int i] => i;
        }
    
        public class A
        {
            public int GetInt() { return new IndexedUno()[1]; }
        }
    
        public class B
        {
            public int GetInt() { return new IndexedDo()[4]; }
        }
    }

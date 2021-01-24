    namespace ConsoleTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var a = new Generic<Concrete>();
                IGeneric<Base> c = new Generic<Base>();
                c = a;
            }
        }
    
        public interface IGeneric<out T> where T: Base
        {
            T Inner { get; }
        }
    
        public class Generic<T> : IGeneric<T>
            where T : Base
        {
            public T Inner { get; set; }
        }
    
        public class Concrete : Base
        {
        }
    
        public class Base
        {
        }
    }

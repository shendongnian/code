    namespace Test
    {
        using MyAlias = First.Second.Third;
        using Fourth.Fifth.Sixth;
    
        public class Program
        {
            static void Main()
            {
                var x = new Thing(); // non aliased
                var y = new MyAlias.Thing(); // aliased
                Console.ReadLine();
            }
    
        }
    }

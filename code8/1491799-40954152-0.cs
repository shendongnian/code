        static void Main(string[] args)
        {
            Console.WriteLine("new Apple()");
            Apple apple = new Apple();
            Console.WriteLine();
            Console.WriteLine("MakeNew<Apple>(apple)");
            Apple anotherApple = MakeNew<Apple>(apple);
        }
        static private T MakeNew<T>(T item) where T: Fruit, new()
        {
            return new T();
        }
        public class Fruit
        {
            public Fruit()
            {
                Console.WriteLine("Fruit Constructor");
            }
        }
        public class Apple : Fruit
        {
            public Apple() : base()
            {
                Console.WriteLine("Apple Constructor");
            }
        }
    }

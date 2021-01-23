        public static void Call(dog d)
        {
            Console.WriteLine("dog is called");
        }
        public static void Call(cat c)
        {
            Console.WriteLine("cat is called");
        }
    }
    class polymorphism
    {
        public static void Main()
        {
            dog dog = new dog();
            cat cat = new cat();
            process.Call(dog);
        }
     }

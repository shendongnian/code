    class process
    {
        public static void Call(dog d) //2
        {
            Console.WriteLine("dog is called");
        }
        public static void Call(cat c) //3
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
            process.Call(dog); //1
        }
    }

    class MyClass
    {       
        static string cheese = "chedar";
        string cheese1 = "global";
        void Main()
        {
            string cheese = "swiss";
            string cheese1 = "local";
           
            Console.WriteLine(cheese);
            Console.WriteLine(MyClass.cheese);
            Console.WriteLine(cheese1);
            Console.WriteLine(this.cheese1);
        }
    }

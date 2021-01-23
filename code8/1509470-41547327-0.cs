        //polymorphism
        class dog
        {
            
        }
        class cat
        {
        }
        class process
        {
            static void Call(dog d)
            {
                Console.WriteLine("dog is called");
            }
            static void Call(cat c)
            {
                Console.WriteLine("cat is called");
            }
        
            public static void Main()
            {
                dog dog = new dog();
                cat cat = new cat();
                Call(dog);
                Console.ReadLine();
            }
        }

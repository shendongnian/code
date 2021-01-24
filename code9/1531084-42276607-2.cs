    class Dog : IAudible
    {
        public void MakeNoise()
        {
            Console.WriteLine("Woof");
        }
    }
    
    class Cat : IAudible
    {
        public void MakeNoise()
        {
            Console.WriteLine("Meow")
        }
    }
    
    IAudible d = new Dog();
    d.MakeNoise(); // Woof
    
    IAudible c = new Cat();
    c.MakeNoise(); // Meow

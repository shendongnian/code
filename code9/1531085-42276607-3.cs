    abstract class Animal
    {
        public string Noise { get; protected set; }
    }
    
    sealed class Dog : Animal
    {
        public Dog()
        {
            Noise = "Woof";
        }
    }
    
    sealed class Cat : Animal
    {
        public Cat()
        {
            Noise = "Meow";
        }
    }
    
    Animal d = new Dog();
    d.Noise; // Woof;
    
    Animal c = new Cat();
    c.Noise; // Meow

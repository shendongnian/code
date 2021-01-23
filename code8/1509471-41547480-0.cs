    using System;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main()
            {
                var dog = new Dog();
                var cat = new Cat();
                var whale = new Whale();
    
                var c = new Caller();
    
                c.CallFeature(dog);
                c.CallFeature(cat);
                c.CallFeature(whale);
    
                Console.ReadKey();
            }
        }
    
        class Cat : Animal
        {
            public override string Feature()
            {
                return "sharp claws";
            }
        }
    
        class Dog : Animal
        {
            public override string Feature()
            {
                return "big teeth";
            }
        }
    
        class Whale : Animal
        {
    
        }
    
        class Animal
        {
            public virtual string Feature()
            {
                return "unknown features";
            }
        }
    
        class Caller
        {
            public void CallFeature(Animal a)
            {
                Console.WriteLine("a {0} has {1}", a.GetType().Name, a.Feature());
            }
        }
    }

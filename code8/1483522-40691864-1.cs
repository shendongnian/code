    class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog("myDog");
            Cat myCat = new Cat("myCat");
            Animal a = new Cat("Garfield");
            Console.WriteLine("Dog {0} has GenusSpecies:{1}", myDog.Name, myDog.GenusSpecies);
            Console.WriteLine("Cat {0} has GenusSpecies:{1}", myCat.Name, myCat.GenusSpecies);
            Console.WriteLine("Animal {0} has GenusSpecies:{1}", a.Name, a.GenusSpecies);
        }
    }

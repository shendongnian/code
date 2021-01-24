    class Program {
        static int GetLegs(IAnimal animal) {
            return animal.GetLegs();
        }
        static void Main(string[] args) {
            Cat cat = new Cat();
            Bird bird = new Bird();
            Console.WriteLine( GetLegs( bird ) ); // 2
            Console.WriteLine( GetLegs( cat ) ); // 4
        }
    }

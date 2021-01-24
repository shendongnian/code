	public class Animal
    {
        public string getId { get { return Dog.ID; } }
    }
    public class Dog : Animal
    {
        public static readonly string ID = "dog";
    }
    ....
    // usage
    Animal a = new Animal();
    Console.WriteLine(a.getId);

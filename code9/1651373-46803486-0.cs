    public abstract class Animal
    {
        public abstract void MakeNoise();
    }
    public class Dog : Animal
    {
        public override void MakeNoise() { Console.WriteLine("Woof"); }
    }
    public class Cat : Animal
    {
        public override void MakeNoise() { Console.WriteLine("Meow"); }
    }
    static void Main()
    {
        Animal a = new Dog();
        Animal b = new Cat();
        a.MakeNoise();
        b.MakeNoise();
    }

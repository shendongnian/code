    public abstract class Animal
    {
        public string Type { get; }
        public string Name { get; }
        protected Animal(string type, string name)
        {
            Type = type;
            Name = name;
        }
    }
    public class Cat : Animal
    {
        public Cat(string name) : base("Cat", name)
        {
        }
    }
    public class Fish : Animal
    {
        public Fish(string name) : base("Fish", name)
        {
        }
    }
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<Animal> list = new List<Animal>();
            list.Add(new Cat("Cheetah"));
            list.Add(new Fish("Dolphin"));
            var cheetahType = list.FirstOrDefault(animal => animal.Name == "Cheetah")?.Type;
            var doplhinType = list.FirstOrDefault(animal => animal.Name == "Dolphin")?.Type;
        }
    }

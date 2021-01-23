    public abstract class Animal
    {
        public readonly string GenusSpecies;
        public string Name { get; set; }
        public Animal(string name)
        {
            Name = name;
            if (this is Dog)
                GenusSpecies = "Canis";
            else if (this is Cat)
                GenusSpecies = "Felis catus";
        }
    }
    public class Dog: Animal
    {
        public Dog(string name): base(name)
        {
            
        }
    }
    class Cat : Animal
    {
        public Cat(string name): base(name)
        {
        }
    }

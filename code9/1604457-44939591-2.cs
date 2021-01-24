    public abstract class Animal
    {
    }
    public interface IAnimalCollection<T> where T : Animal
    {
        void Add<T>(T animal);
    }
    public class Cat : Animal, IAnimalCollection<Cat>
    {
        public void Add(Cat animal)
        {
        }
    }
    public class Dog : Animal, IAnimalCollection<Dog>
    {
        // won't compile
        public void Add(Animal animal)
        {
        }
    }
    public class Ferret : IAnimalCollection<Ferret>
    {
        public void Add(Ferret animal)
        {
        }
        public void Add(Animal animal)
        {
        }
    }
    // won't compile
    public class Foo : IAnimalCollection<Foo>
    {
        public void Add(Foo animal)
        {
        }
    }

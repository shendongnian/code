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
        public void Add(Dog animal)
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

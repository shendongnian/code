    public interface INameable
    {
        string Name { get; set; }
    }
    public interface IMeasurable
    {
        int Height { get; set; }
    }
    abstract class Animal: INameable
    {
        public string Name { get; set; }
    }
    class Dog : Animal { }
    class Cat : Animal { }
    abstract class Furniture: IMeasurable
    {
        public int Height { get; set; }
    }
    class Chair : Furniture { }
    class TallDog : Animal, IMeasurable
    {
        public int Height { get; set; }
    }
    public T NameableFactory<T>(string name)
        where T:INameable, new()
    {
        return new T { Name = name };
    }
    public T MeasurableFactory<T>(int height)
        where T : IMeasurable, new()
    {
        return new T { Height = height };
    }
    public T NameableMeasurableFactory<T>(string name, int height)
        where T : INameable, IMeasurable, new()
    {
        return new T { Name = name , Height = height };
    }
    [TestMethod]
    public void TestFactories()
    {
        Cat ct = NameableFactory<Cat>("milo");
        Chair ch = MeasurableFactory<Chair>(5);
        TallDog td = NameableMeasurableFactory<TallDog>("Fido", 5);
    }

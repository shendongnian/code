    public class Animal
    {
        public string Name;
        public Animal() { Name = "Animal"; }
    }
    public class Dog:Animal
    {
        public Dog() { Name = "Dog"; }
    }
    [TestMethod]
    public void Test()
    {
        var list = new List<Animal>();
        list.Add(new Dog());
        list.Add(new Animal());
        foreach(var a in list)
        {
            DoStuff(a);
        }
    }
    public void DoStuff(Animal animal)
    {
        Console.WriteLine("{0} is wild", animal.Name);
    }
    public void DoStuff(Dog dog)
    {
        Console.WriteLine("{0} is not wild", dog.Name);
    }

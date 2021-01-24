    public interface IMammal
    {
    }
    public class Dog : IMammal
    {
        public void Bark()
        {
            Console.WriteLine("Woof");
        }
    }
    public class Cat : IMammal
    {
        public void Meow()
        {
            Console.WriteLine("meow");
        }
    }
    public class Pet
    {
        public virtual IMammal Animal { get; set; }
    }

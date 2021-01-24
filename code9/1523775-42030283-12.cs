    public abstract class Animal
    {
        public int Id { get; set; }
    }
    public abstract class Pet : Animal
    {
        public virtual ICollection<Toy> Toys { get; set; }
    }
    public class Cat : Pet
    {
        public string Name { get; set; }
    }
    public class Dog : Pet
    {
        public int CollarColor { get; set; }
    }
    public class Rat : Animal
    {
    }
    public class Toy
    {
        public int Id { get; set; }
        public Pet Owner { get; set; }
    }

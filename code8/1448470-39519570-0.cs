    public class Mammal
    {
        public Mammal(Mammal toCopy)
        {
            Name = toCopy.Name;
            Number = toCopy.Number;
        }
        public string Name {get; set;}
        public int Number {get; set;}
    }
    public class Person: Mammal
    {
        public Person(Mammal toCopy) {} /* will default to base constructor */
    }
    public class Dog: Mammal
    {
        public Dog(Mammal toCopy) {} /* will default to base constructor */
    }

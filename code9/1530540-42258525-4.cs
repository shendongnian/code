    public interface IAnimal
    {
        void Eat();
    }
    
    public interface ISpeakable
    {
        string Speak();
    }
    
    public class Cat : IAnimal, ISpeakable
    {
        public Cat()
    
        public void Eat()
        { 
             //Do something
        }
    
        public string Speak()
        {
            return "meow";
        }
    }
    public class Fish : IAnimal 
    {
        public Fish()
    
        public void Eat()
        { 
             //Do something
        }
    }

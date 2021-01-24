    public interface IAnimal
    {
        void Eat();
    }
    
    public interface ISpeakingAnimal : IAnimal
    {
        string Speak();
    }
    
    public class Cat : ISpeakingAnimal 
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

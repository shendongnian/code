    public interface IAnimal
    {
        void Eat();
        void Speak();
    }
    
    public class Cat : IAnimal
    {  
        public void Eat() {  }
        
        public string Speak()
        {
            return "meow";
        }   
    }
    public class Dog : IAnimal
    {  
        public void Eat() {  }
        
        public string Speak()
        {
            return "au";
        }   
    }

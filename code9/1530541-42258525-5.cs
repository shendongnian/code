    public class Cat : ISpeakingAnimal 
    {
        public Cat()
    
        public void Eat()
        { 
             //Do something
        }
    
    
        string ISpeakingAnimal.Speak()
        {
            return Meow();
        }
        public string Meow()
        {
            return "meow";
        }
    }

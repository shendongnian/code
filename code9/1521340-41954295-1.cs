    public abstract class Animal
    {
        protected abstract void Constructor();
    
        protected Animal()
        {
            Constructor();
        }
    
        public class Factory
        {
            public static Animal CreateAnimal()
            {
                return new Animal();
            }
        }
    }  

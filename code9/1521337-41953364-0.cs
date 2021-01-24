    public abstract class Animal
    {
        protected abstract void Constructor();
    
        public Animal(bool DoNotAllowDefaultConstructor)
        {
            Constructor();
        }
    }

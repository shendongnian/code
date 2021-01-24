    public abstract class Animal
    {
        private static int _count;
        protected Animal()
        {
            IncrementCount();
        }        
        protected static void IncrementCount()
        {
            _count++;
        }
        public int WorldPopulation()
        {
            return _count;
        }
    }
    public class Dog : Animal
    {
        
    }
    public class Cat : Animal
    {
    }
    public class Bird : Animal
    {
    }

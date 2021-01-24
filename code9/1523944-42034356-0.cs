    public class Animal<T> where T : Animal<T>
    {
        public readonly string ID = typeof(T).Name;
    }
    
    public class Dog : Animal<Dog>
    {
    }
    
    public class Cat : Animal<Cat>
    {
    }

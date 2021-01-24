    public class Animal<T> where T : Animal<T>
    {
        public static readonly string ID = typeof(T).Name;
    }
    
    public class Dog : Animal<Dog>
    {
    }
    
    public class Cat : Animal<Cat>
    {
    }

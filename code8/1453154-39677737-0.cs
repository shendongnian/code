    public class A<T> where T : B
    {
        public T Details { get; set; }
    }
    public class Aext : A<Bext>
    {
    }
    public class B
    {
        
    }
    public class Bext : B
    {
        
    }

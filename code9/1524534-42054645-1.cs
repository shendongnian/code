    internal class Something 
    {
        ...
    }
    public class Program 
    {
        public static Something s = new Something(); // compilation error: class 'Something' is internal but 's' is public
    }

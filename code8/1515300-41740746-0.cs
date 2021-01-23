    public interface IObjectComparison
    {
        object GetPropertyValue(string property);
    }
    public class MyObject : IObjectComparison
    {
        public object GetPropertyValue(string property)
        {
            return new object();
        }
    }
    class Program
    {
        static void Main()
        {
            MyObject mo = new MyObject();
            IObjectComparison imo = (IObjectComparison)mo;
        }
    }

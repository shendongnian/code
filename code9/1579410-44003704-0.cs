    class Program
    {
        static void Main(string[] args)
        {
            var t = new Container {Name = "Test", P1 = new MyType {Val = "1"}, P2 = new MyType {Val = "2"} };
            var res = t.OfType<MyType>();
        }
        public class Container
        {
            public string Name { get; set; }
            public MyType P1 { get; set; }
            public MyType P2 { get; set; }
        }
        public class MyType
        {
            public string Val { get; set; }
        }
    }
    public static class ObjectExtensions
    {
        public static Dictionary<string, T> OfType<T>(this object o)
        {
            return o.GetType().GetProperties().Where(p => p.PropertyType == typeof(T)).ToDictionary(p => p.Name, p => (T)p.GetValue(o));
        }
    }

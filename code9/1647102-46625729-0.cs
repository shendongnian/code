    public interface IDesc
    {
        string Name { get; }
        string Description { get; }
    }
    public static class Desc<T> where T : IDesc, new()
    {
        public static string Name
        {
            get
            {
                var property = typeof(T).GetProperty("Name");
                return property.GetValue(new T()) as string;
            }
        }
        public static string Description
        {
            get
            {
                var property = typeof(T).GetProperty("Description");
                return property.GetValue(new T()) as string;
            }
        }
    }
    public class MyClass : IDesc
    {
        public string Name { get { return "name of class"; } }
        public string Description { get { return "description"; } }
    }

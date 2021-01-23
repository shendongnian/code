    public interface IInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class GenericClass<T> where T : IInfo
    {
        public GenericClass(T obj)
        {
            DynamicObject = obj;
        }
        public T DynamicObject { get; set; }
        public void UseClassPro()
        {
            Console.WriteLine("Address " + DynamicObject.Address);
        }
    }

    public interface IInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class A
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public A(string _name, string _address)
        {
            Name = _name;
            Address = _address;
        }
    }
    public class B
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public B(string _name, string _address)
        {
            Name = _name;
            Address = _address;
        }
    }
    public class C
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public C(string _name, string _address)
        {
            Name = _name;
            Address = _address;
        }
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

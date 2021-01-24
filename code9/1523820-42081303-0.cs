    public class MyClass
    {
        public string Name { get; set; }
    }
    
    public static class MyClassExtensions
    {
        public static MyClass Clone(this MyClass obj)
        {
            return new MyClass()
            {
                Name = obj.Name
            };
        }
    }

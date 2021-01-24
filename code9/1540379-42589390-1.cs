    class Program
    {
        static void Main(string[] args)
        {
            object plugin = new A();
            string json = "{\"Property\":\"foo\"}";
            var invoker = new JsonInvoker(plugin.GetType(), "Process");
            //here I call invoker with simple string.
            var output = invoker.Invoke(plugin, json);
        }
    }
    public class A
    {
        public C Process(B input)
        {
            return new C
                   {
                       Property = input.Property + " bar"
                   };
        }
    }
    public class C
    {
        public string Property { get; set; }
    }
    public class B
    {
        public string Property { get; set; }
    }

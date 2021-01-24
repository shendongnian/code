    class ArgumentType
    {
        
    }
    class Foo
    {
        public void Bar(ArgumentType argument)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Foo);
            var argument = new ArgumentType();
            t.GetMethod("Bar").Invoke(this, new object[] { argument });
        }
    }

    class Person
    {
        public string GetName() { return "John Doe"; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person();
            Do(p.GetName);  //Notice no () after GetName
        }
        static void Do(Func<string> f)
        {
            Console.WriteLine(String.Format("The caller sent the value '{0}' via a method named {1}", f.Invoke(), f.Method.Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MyClass.Function1<string>());
            Console.WriteLine(MyClass.Function1<IEnumerable<string>>());
            Console.WriteLine(MyClass.Function1<IDictionary<string, string>>());
            Console.WriteLine(MyClass.Function1<IDictionary<string, IEnumerable<string>>>());
            Console.WriteLine(MyClass.Function2<string>());
            Console.WriteLine(MyClass.Function2<IEnumerable<string>>());
            Console.WriteLine(MyClass.Function2<IDictionary<string, string>>());
            Console.WriteLine(MyClass.Function2<IDictionary<string, IEnumerable<string>>>());
            // Static Method:
            var strObj = "string";
            Console.WriteLine(strObj.StaticMethod1());
            Console.WriteLine(strObj.StaticMethod2());
            IEnumerable<string> listObj = new List<string>();
            Console.WriteLine(listObj.StaticMethod1());
            Console.WriteLine(listObj.StaticMethod2());
            IDictionary<string, string> dicObj = new Dictionary<string, string>();
            Console.WriteLine(dicObj.StaticMethod1());
            Console.WriteLine(dicObj.StaticMethod2());
            IDictionary<string, IEnumerable<string>> dicLisObj = new Dictionary<string, IEnumerable<string>>();
            Console.WriteLine(dicLisObj.StaticMethod1());
            Console.WriteLine(dicLisObj.StaticMethod2());
        }
    }

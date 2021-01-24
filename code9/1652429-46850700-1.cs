    class Program
    {
        static void Main(string[] args)
        {
            var test = new MyClass();
            test.DoTest(out var result);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
    class MyClass
    {
        public ReadOnlyCollection<MyCustomClass> DoTest(out string functionOutVariable)
        {
            var result = new List<MyCustomClass>();
            var list1 = this.returnEmptyList();
            var list2 = this.returnListWithOneItem();
            if (list1.Count == 0 && list2.Count == 0)
            {
                functionOutVariable = string.Empty;
                return result.AsReadOnly();
            }
            functionOutVariable = string.Empty;
            return result.AsReadOnly();
        }
        private List<string> returnEmptyList()
        {
            return new List<string>();
        }
        private List<string> returnListWithOneItem()
        {
            return new List<string> { "something" };
        }
    }
    class MyCustomClass
    {
        
    }

     class Test1
    {
        public static List<string> myList = new List<string>() { "11","22","33"};
        public object myListToArray()
        {
            return myList.ToArray();
        }
    }
    class Test2
    {
        public void Test()
        {
            var test = new Test1();
            Parallel.ForEach((test.myListToArray() as IEnumerable<string>), (value) => { Console.WriteLine(value); });
           
        }
    }

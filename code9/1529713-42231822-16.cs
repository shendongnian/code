    public static void ProceesDataD<T>(IList<T> param1, string date1)
    {
        Parallel.ForEach(param1, (currentItem) =>
        {
            dynamic obj = currentItem;
            int custId = obj.CustID;
            Thread.Sleep(10);
        });
    }
    public static void ProceesData<T>(IList<T> param1, string date1) where T : ICust
    {
        Parallel.ForEach(param1, (currentItem) =>
        {
            var value = currentItem.CustID;
            Thread.Sleep(10);
        });
    }
    public static void ProceesData<T>(IList<T> param1, string date1, string parameter)
    {
        PropertyInfo pi = typeof(T).GetProperty(parameter);
        Parallel.ForEach(param1, (currentItem) =>
        {
            var value = pi.GetValue(currentItem);
            Thread.Sleep(10);
        });
    }
    public static void Main(string[] args)
    {
        List<ClassA> test = new List<ClassA>();
        List<A> testA = new List<A>();
        Stopwatch st = new Stopwatch();
        for (int i = 0; i < 10000; i++)
        {
            test.Add(new ClassA { CustID = 123, Name = "Me" });
            testA.Add(new A { CustID = 123, Name = "Me" });
        }       
        st.Start();
        ProceesData<ClassA>(test, "test", "CustID");
        st.Stop();
        Console.WriteLine("Reflection: " + st.ElapsedMilliseconds);
        st.Restart();
        ProceesData<A>(testA, "test");
        st.Stop();
        Console.WriteLine("Interface: " + st.ElapsedMilliseconds);
        
        st.Restart();
        ProceesDataD<ClassA>(test, "test");
        st.Stop();
        Console.WriteLine("Dynamic: " + st.ElapsedMilliseconds);
    }

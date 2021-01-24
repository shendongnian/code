    public class ClassA
    {
          public int CustID { get; set; }
          public string Name { get; set; }
    }
    public class ClassB
    {
          public int CustID { get; set; }
         public string Age { get; set; }
    }
    public static void ProceesData<T>(IList<T> param1, string date1)
    {
        Parallel.ForEach(param1, (currentItem) =>
        {
            // I want to aceess CustID property of param1 and pass that value to another function
            var value = typeof(T).GetProperty("CustID").GetValue(currentItem);
            Console.WriteLine("Value: " + value);
        });
    }
    public static void Main(string[] args)
    {
        List<ClassA> test = new List<ClassA>();
        test.Add(new ClassA { CustID = 123 });
        test.Add(new ClassA { CustID = 223 });
        test.Add(new ClassA { CustID = 323 });
        ProceesData<ClassA>(test, "test");
    }

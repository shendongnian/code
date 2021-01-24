    static void Main()
    {
       List<object> dd = new List<object>() { 1, 2, "a", "b", 8 };
       var dd2 = new List<int>(GetIntegersFromList(dd));
       dd2.ForEach(j => Console.Write("{0}\t", j));
        
        Console.ReadKey();
    }
    public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
    {
          return listOfItems.OfType<int>().ToList();
    }

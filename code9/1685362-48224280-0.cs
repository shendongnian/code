    static void Main(string[] args)
    {
       var testList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
       var mapList = Map<int, int>(x => x + 2, testList);
 
       mapList.ToList<int>().ForEach(i => Console.Write(i + " "));
       Console.WriteLine();
       Console.ReadKey();
    }
 
    static IEnumerable<TResult> Map<T, TResult>(Func<T,TResult> func, 
    IEnumerable<T> list)
    {     
        foreach (var i in list)
           yield return func(i);
    }

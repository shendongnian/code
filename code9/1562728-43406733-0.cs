    public static Task LongOperationAsync(List<String> names, Action<String> progress, string id)
    {
        return Task.Factory.StartNew(() =>
       {
           foreach (var item in names)
           {
               // do some long operation
               progress($"{id}: {item.ToUpper()}");
           }
       });
    }
    static void Main(string[] args)
    {
        var friends = new List<String>() {"joey","ross","chandler","monica","phoebe","rachel" };
        var scienfelds = new List<String>() { "Jerry", "kramer", "george", "elaine" };
        Action<String> resultProcessor = (result) =>
        {
            // process the result. let's say update the UI as and when results arrive
            Console.WriteLine(result);
        };
        var task1 = LongOperationAsync(friends, resultProcessor, "task1");
        var task2 = LongOperationAsync(scienfelds, resultProcessor, "task2");
        Task.WaitAll(task1, task2);
        Console.ReadLine();
    }

    public static void Main()
    {
        var watcher = new CreatedFileCollection(CancellationToken.None, "c:\\test");
        var enumerator = watcher.GetEnumerator();
        Task.Run(() =>
        {
            //This will block until either a new file is created or the 
            //passed CancellationToken is cancelled.
            while (enumerator.MoveNext()) 
            {
                Console.WriteLine("New File - " + enumerator.Current);
            }
        });
        Console.ReadLine();
    }

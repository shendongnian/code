     static void Main()
    {
        string n = @"C:\testFolder";
        DateTime dtime1 = new DateTime(2015, 1, 3);
        if (Directory.Exists(n))
        {
             Directory.SetCreationTime(n, dtime1);
             Directory.SetLastWriteTime(n, dtime1);
             var directories = Directory.GetDirectories(n);
       
             foreach(directory in directories)
             {
                  Directory.SetCreationTime(directory , dtime1);
                  Directory.SetLastWriteTime(directory , dtime1);
             }
        }
        Console.WriteLine("Done");
    }

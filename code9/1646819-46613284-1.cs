    static void Main()
    {
        string n = @"C:\testFolder";
        DateTime dtime1 = new DateTime(2015, 1, 3);
    
        if (Directory.Exists(n)) {
            string[] allSubDirectories = Directory.GetDirectories(n, "*", SearchOption.AllDirectories);
            foreach(var dir in allSubDirectories) {
                Directory.SetCreationTime(n, dtime1);
                Directory.SetLastWriteTime(n, dtime1);
            }
        }
        
        Console.WriteLine("Done");
    }

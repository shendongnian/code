    static void Main(string[] args) {
        var tmpFile = Path.GetTempFileName();
        // file is now created
        new Thread(() => {
            using (var fs = new FileStream(tmpFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete)) {
                // open with permissive share mode, including FileShare.Delete
                // and hold that handle for 5 seconds
                Thread.Sleep(5000);
            }
        }).Start();
        // wait a bit for thread above to grab a handle
        Thread.Sleep(1000);
        // delete, will return fine without any errors            
        File.Delete(tmpFile);
        // attempt to create - will fail with access denied exception you have
        using (var s = new StreamWriter(tmpFile)) {
            s.Write("aaa");
        }
        Console.WriteLine("done");
        Console.ReadLine();
    }

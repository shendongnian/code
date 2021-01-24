    static void Main(string[] args)
    {
        //async testing - 5 files batch
        Console.WriteLine("Job Start:");
        var tasks = new Task[5];
        for (int i = 0; i < 5; i++)
        {
            var filestream = File.Open(@"c:\pdftest\" + i.ToString() +@".docx", FileMode.Open);
            //Moved i.ToString() out of the delegate to fix a potential bug with variable capture.
            var stringToPrint = i.ToString()
            //delegate
            Func<Task> act = async () =>
            {
                await test(filestream, stringToPrint);
                filestream.Dispose();
            };
            var task = act();
            tasks[i] = task;
        }
        //In a non console program you will likely want to do "await Task.WhenAll(tasks);" instead.
        Task.WaitAll(tasks);
        Console.WriteLine("End.");
        Console.ReadLine();
    }

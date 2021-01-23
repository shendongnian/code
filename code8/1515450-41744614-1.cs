    public void MyProcess(FileItem file)
    {
        List<string> lines = file.GetLines(); //some process to get the lines to handle
        long cntr = 0; //The counter to track
    
        Parallel.ForEach(lines, crntLine =>
        {
           //...Code to process crntLine here
    
           InterLocked.Increment(ref cntr);
           Console.Writeline(String.Format("Currently finished {0} out of {1} lines",cntr,lines.Count());
        });
    }

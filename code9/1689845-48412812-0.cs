    public static void yourMethod(int id){
    
        var tasks = new List<IMyCustomType> { new dbA.GetA(id), new dbB.GetB(id), new dbC.GetC(id), new dbD.GetD(id)};
        // Your simple stopwatch for timing
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
            
        // For each 'tasks' list item, call 'executeTasks' (Max 10 occurrences)
        // - Processing for all tasks will be complete before 
        //   continuing processing on the main thread
        Parallel.ForEach(tasks, new ParallelOptions { MaxDegreeOfParallelism = 10 }, executeTasks);
            
        stopWatch.Stop();
        Console.WriteLine("Completed execution in:  " + stopWatch.Elapsed.TotalSeconds);
    }
    private static void executeTasks(string obj)
    {
        // Your task's work here. 
    }

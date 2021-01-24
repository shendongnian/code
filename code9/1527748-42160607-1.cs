    // Options to the set maximum number of threads. 
    // This is not necessary, .NET will try to use the best amount of cores there is. (as pointed out by Panagiotis Kanavos)
    // Overload of method is available without the options parameter
    var options = new ParallelOptions()
    {
        MaxDegreeOfParallelism = 4 // maximum number of threads
    };
    // The body on the loop
    Action<int> loopBody = i =>
    {
        DoWorkOnItem(i); // Method implementation for a single item
    };
    // The result. Check for loopResult.IsCompleted if everything went correctly
    var loopResult = Parallel.For(0, 45856582, options, loopBody);

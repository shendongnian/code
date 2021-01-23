    Stopwatch watch = Stopwatch.StartNew();
 
    DoSomething();
 
    watch.Stop();       // Stops measuring time
    Debugger.Break();   // Programatically breaks the program at this point
    watch.Start();      // Resumes measuring time
    
    DoAnotherThing();
    DoFinalThings();
    watch.Stop();

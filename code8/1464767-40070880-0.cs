    TimeSpan start = TimeSpan.Parse("15:09"); 
    TimeSpan now = DateTime.Now.TimeOfDay;
    
    Action<object> action = (s) => { Console.WriteLine(s); }; // what needs to be executed
    // a 'negative' timespan means we're not there yet
    TimeSpan diff = now - start;
    // within the minute
    if (diff.TotalSeconds > -1 && diff.TotalSeconds < 60) {
       action("awesome"); // execute
    } 
    else
    {
        // if we are to early...
        if (diff.TotalSeconds<0) 
        {
            // ... schedule the work with a timer
            // waiting for the difference in the diff TimeSpan to pass
            new System.Threading.Timer((state) => action(state), // execute
                "FooBar",  // state
                diff.Duration(),  // how long to wait for the abolsute Duration 
                new TimeSpan(-1));  // no repeat
        }
        else
        {
            // we are late ...
        }
    }

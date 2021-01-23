    var duration = new List<string>() { "116:48:28", "110:36:28", "16:30:28" };
    string largestInput = "";
    TimeSpan largestTimespan = new TimeSpan(0);
    foreach (string d in duration)
    {
        TimeSpan parse = ParseSpecialTimespan(d);
        if (parse > largestTimespan)
        {
            largestTimespan = parse;
            largestInput = d;
        }
    }
    System.Diagnostics.Debug.Print(@"Largest timespan is ""{0}"" from input ""{1}"".", largestTimespan.ToString(), largestInput); 

    void Main()
    {
        ReadFromBeginToEnd("13:08:30:62","13:08:30:7",@"sample.txt");
    }
    
    // enumerate over the lines from the streamreader
    // accepting two regexes, start and end
    IEnumerable<string> FromBeginToEnd(StreamReader sr, Regex start, Regex end)
    {
       // 1st state
       var line = sr.ReadLine(); // initial read, null means we're done
       // read the lines until we hit our start match
       while(line != null && !start.Match(line).Success) 
       {
          // don't return these lines
          line = sr.ReadLine();    
       }
       // 2nd state
       // read the lines while we didn't hit our end match
       while(line != null && !end.Match(line).Success) 
       {
          // return this line to the caller
          yield return line;
          line = sr.ReadLine();    
       }
       // 3rd state
       // read the lines while we find our end match
       while(line != null && end.Match(line).Success) 
       {
          // return this line to the caller
          yield return line;
          line = sr.ReadLine();    
       }
       // iterator is done
       yield break;
    }
    
    // take a start and end string that can be compiled to a regex
    // and a file (fullpath)
    void ReadFromBeginToEnd(string start, string end, string file) 
    {
        // use a streamreader to read characters
        // the .ctor accpets an Encoding as second parameter
        using(var sr = new StreamReader(file))
        {
            // loop over the lines that mach the criteria
            // FromBeginToEnd is our custom enumerator
            foreach(var line in FromBeginToEnd(sr, new Regex(start), new Regex(end)))
            {
               // write to standard out
               // but this can be an StreamWriter.WriteLine as well.
               Console.WriteLine(line);
            }
        }
    }

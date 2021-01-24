    void Main()
    {
        // use a streamreader to read characters
        // the .ctor accpets an Encoding as second parameter
        using(var sr = new StreamReader(@"sample.txt"))
        {
            ReadFromBeginToEnd("13:08:30:62","13:08:30:7",sr);
        }
  
        var text =@"
    13:08:30:6227343 Main: 41044 - 48.7617 M-- Other PIDS 2 - 79.1016 M
    13:08:30:6757752 Main: 41044 - 48.7617 M-- Other PIDS 2 - 79.1016 M
    13:08:30:7208103 Main: 41044 - 48.7617 M-- Other PIDS 2 - 79.1016 M
    13:08:30:7668739 Main: 41044 - 48.7617 M-- Other PIDS 2 - 79.1016 M";
        using(var sr = new StringReader(text))
        {
            ReadFromBeginToEnd("13:08:30:62","13:08:30:7", sr);
        }
    }
    
    // enumerate over the lines from the streamreader
    // accepting two regexes, start and end
    IEnumerable<string> FromBeginToEnd(TextReader rdr, Regex start, Regex end)
    {
       // 1st state
       var line = rdr.ReadLine(); // initial read, null means we're done
       // read the lines until we hit our start match
       while(line != null && !start.Match(line).Success) 
       {
          // don't return these lines
          line = rdr.ReadLine();    
       }
       // 2nd state
       // read the lines while we didn't hit our end match
       while(line != null && !end.Match(line).Success) 
       {
          // return this line to the caller
          yield return line;
          line = rdr.ReadLine();    
       }
       // 3rd state
       // read the lines while we find our end match
       while(line != null && end.Match(line).Success) 
       {
          // return this line to the caller
          yield return line;
          line = rdr.ReadLine();    
       }
       // iterator is done
       yield break;
    }
    
    // take a start and end string that can be compiled to a regex
    // and a file (fullpath)
    void ReadFromBeginToEnd(string start, string end, TextReader reader) 
    {
        // loop over the lines that mach the criteria
        // FromBeginToEnd is our custom enumerator
        foreach(var line in FromBeginToEnd(reader, new Regex(start), new Regex(end)))
        {
           // write to standard out
           // but this can be an StreamWriter.WriteLine as well.
           Console.WriteLine(line);
        }
    }

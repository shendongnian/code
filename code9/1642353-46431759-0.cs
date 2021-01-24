    using System.Collections.Generic;
        
    ...
    
    List<string> lines = new List<string>();
    lines.Add(dateTM);
    lines.Add("Hello World!");
    File.WriteAllLines(MainPath + @"Log\Client-side.txt", lines);
   

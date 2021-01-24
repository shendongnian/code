    bool bufferready = false;
    string prev1="", prev2="";
    StringBuilder result = new StringBuilder();
    foreach (string line in File.ReadLines("path"))
    {
       if (line.StartsWith("D"))
       {
           if (bufferready)
           {
               result.AppendLine(prev1);
               result.AppendLine(prev2);
               bufferready = false;
           }
           result.AppendLine(line);
       }
       else
       {
          prev1 = prev2;
          prev2 = line;
          bufferready = true;
       }
    }

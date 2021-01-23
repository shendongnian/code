       var lines = File.ReadAllLines(Fullpath);
       var last = lines.Last();
       foreach (string s in lines)
       {
           if (s.Equals(last))
           {
               text.AppendLine(s.Replace("OK", "NG"));
           }
           else
           {
               text.AppendLine(s);
           }
       }

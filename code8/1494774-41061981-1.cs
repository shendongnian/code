       // Line: 0 for lowest cubes
       private static int CubeLine(string value, string[] stack) {
          int line = 0;
    
          while (true) {
            string parent = value.Substring(value.IndexOf('|') + 1);
    
            if ("0".Equals(parent))
              return line;
    
            line += 1;
            value = stack.First(item => item.StartsWith(parent + "|"));
          }
        }
    

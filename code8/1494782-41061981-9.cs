       // Line: 0 for lowest cubes
       private static int CubeLine(string value, IEnumerable<String> stack) {
          for (int line = 0; ; ++line) {
            string parent = value.Substring(value.IndexOf('|') + 1);
    
            if ("0".Equals(parent))
              return line;
    
            value = stack.First(item => item.StartsWith(parent + "|"));
          }
        }
    

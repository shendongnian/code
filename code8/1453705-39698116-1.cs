      private static IEnumerable<String> ConvertMe(String path) {
        int kind = 0;
        int groupCount = 0;
    
        foreach (string line in File.ReadLines(path)) {
          if (kind == 0) { // file header: 1st line
            kind = 1;
            yield return line;  
    
            continue; 
          }       
          else if (kind == 1) { // file header: 2nd line
            kind = 2;
            yield return line;
    
            continue; 
          }   
    
          string items[] = line.Split(' ');
    
          if (kind = 2) { // group header
            kind = 3;
            yield return line; 
    
            groupCount = int.Parse(items[0]); 
    
            continue;
          }
    
          // Longitude + Latitude
          double lat = double.Parse(items[0]); 
          double lon = double.Parse(items[1]);
          double distance = ...; //TODO: your formula here
    
          yield return distance.ToString(CultureInfo.InvariantCulture);
    
          groupCount -= 1;
    
          if (groupCount <= 0) 
            kind = 2;
        } 
      }
...
      String path = @"C:\MyData.txt";
    
      // Materialization (.ToList) if we write in the same file
      File.WriteAllLines(path, ConvertMe(path).ToList()); 

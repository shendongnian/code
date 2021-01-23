     private static Dictionary<string, int[]> build_named_data(int height, int width) {
       Dictionary<string, int[]> result = new Dictionary<string, int[]>();
       for (int i = 1; i <= height; ++i) {
         int[] line = new int[width];
         for (int j = 0; j < line.Length; ++j)
           line[j] = s_Gen.Next(2);   
         result.Add($"a{i}", line); 
       } 
       return result;
     }
      
     ....
     var myData = build_named_data(15, 20); 
     int[] array = build_named_data["a3"]; 

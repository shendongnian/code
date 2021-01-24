     string param = "1100,1110,0110,0001";
     string[] resultantArray = param.Split(',').ToArray();
      var max = resultantArray.OrderByDescending(s => s.Length).First();
      int n = resultantArray.Length;            
      int m = max.Length;
      var matrix = new int[n, m];
      for (int i = 0; i < resultantArray.Count(); i++)
      {
         string str = resultantArray[i];
         char[] allChars = str.ToCharArray();
         for (int j = 0; j < allChars.Count(); j++)
         {
              matrix[i, j] = Convert.ToInt32(allChars[j].ToString()); 
         }
      }

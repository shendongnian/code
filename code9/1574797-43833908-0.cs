    int[] practiceArray = new int[10] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
    int[] practiceArray2 = new int[practiceArray.Length];
    
      for (int index = 0; index < practiceArray.Length; index++)
      {
        practiceArray2[index] = practiceArray[index];
      }
     
      foreach (int pArray in practiceArray)
        Console.Write(pArray + " ");      
    
      foreach (int pArray2 in practiceArray2)
        Console.Write(pArray2 + " ");
      
      Console.Read();

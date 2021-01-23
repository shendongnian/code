      int[] array1 = new int[10];
      int[,] array2= new int[10,3];  
      int[,,] array3 = new int[10,1,2]; 
      Console.WriteLine("{0}: {1} dimension(s)", 
                        array1.ToString(), array1.Rank);
      Console.WriteLine("{0}: {1} dimension(s)", 
                        array2.ToString(), array2.Rank);
      Console.WriteLine("{0}: {1} dimension(s)", 
                        array3.ToString(), array3.Rank);

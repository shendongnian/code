      using System;
      using System.Collections.Generic;
      using System.IO;
      
      class Solution 
      {
          static void Main(String[] args) 
          {
                string[] firstLine = Console.ReadLine().Split(' ');     
                int numInts = Convert.ToInt32(firstLine[0]);               //Number of ints in list
                int rotations = Convert.ToInt32(firstLine[1]);             //number of left rotations
                int[] numList = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);    //the list to rotate
               for( var i = 0 ; i < numInts ; ++i )
                   Console.WriteLine( numList [ (i + rotations) % numInts ] );
            }
        }

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    class Solution 
    {
    
        static void Main(String[] args) 
        
        {
            int i, j, z;
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp,Int32.Parse);
            
            int[] temparray = new int[2*n];
            
            //constraints
            if(n >= 100000 || n < 1 )
                {
                System.Environment.Exit(1);
                }
            
            if(k > n || n < 1 )
                {
                System.Environment.Exit(1);
                }  
      
            for(i = 0; i< n; i++)
            {
                   if(a[i] > 1000000 || a[i] < 1 )
                   {
                   System.Environment.Exit(1);
                   }     
             } 
      
    
            for(j = 0; j<n; j++)
                {
                z = (j-k) %n;
                
                if(z != 0)
                    {
                    z= (n+ z) %n;
                    }
                
                temparray[z] = a[j];
                }
          
            //view array
            for(i = 0; i< n; i++)
                {
            Console.Write(temparray[i] + " " );      
                }
            
                
        }
    }

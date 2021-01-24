    using System;
    using System.IO;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;
    class Solution
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            string[] inputs = Console.ReadLine().Split(' ');
            int closest=0;
            if(n>0)
            {
              closest=int.Parse(inputs[0]);
              for (int i = 1; i < n; i++)
              {
                int t = int.Parse(inputs[i]); 
                if(Math.Abs(closest-0)>Math.Abs(t-0))
                {closest=t;}
                else if(Math.Abs(closest-0) == Math.Abs(t-0))
                {
                    if(closest-Math.Abs(closest)==0 && t-Math.Abs(t)==0)
                    {closest=closest;}
                    else if(closest-Math.Abs(closest)==0)
                    {closest=closest;}
                    else if(t-Math.Abs(t)==0)
                    {closest=t;}
                }
             }
           }
              Console.WriteLine(closest);
          }
       }

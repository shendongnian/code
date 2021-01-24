    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
        namespace Rextester
        {
            public class Program
            {
                public static void Main(string[] args)
                {
                    //Your code goes here
                    Console.WriteLine("Hello, world!");
                int[] arryofdays = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
                int num = Int32.Parse(Console.ReadLine());
                int temp = num;
                string date, month;
        
                for (int i = 0; i < arryofdays.Length; i++)
                {
        
                    temp =(temp - arryofdays[i]);
                    if (temp < arryofdays[i + 1] && temp >0)
                    {
                        Console.WriteLine("Date:" + temp.ToString());
                        Console.WriteLine("Month:" + (i+2).ToString());
                        break;
                    }else{//for handling first month
                        Console.WriteLine("Date:" +num);
                        Console.WriteLine("Month:" + 1);
                        break;
                    }
                }
        
                Console.ReadLine();
                }
            }
        }

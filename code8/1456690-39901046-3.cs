    using System;
    using System.Collections.Generic;
    
    
    namespace Application
    {
        class MyTest
        {
            List<dynamic> array_list = new List<dynamic> { };
            int length;
    
            public void AddArray(dynamic dynamic_array)
            {
                this.array_list.Add(dynamic_array);
                this.length = dynamic_array.Length;
            }
            public dynamic GetVector(int ndx)
            {
                return array_list[ndx];
            }
            public void Display()
            {
                for (int ndx = 0; ndx < this.length; ndx++)
                {
                    string ln_txt = "";
                    foreach (var array_from_list in this.array_list)
                    {
                        string s = array_from_list[ndx].ToString();
                        ln_txt += $"{s} ";
                    }
    
                    Console.WriteLine(ln_txt);
                }
    
            }
        }
    
        static class Program
        {
    
            
            [STAThread]
            static void Main(string[] args)
            {
    
                MyTest test = new MyTest();
                test.AddArray(new long[] { 10, 20, 30, 40 });
                test.AddArray(new int[] { 1, 2, 3, 4 });
                test.AddArray(new double[] { .1, .2, .3, .4 });
                test.AddArray(new string[] { "a", "b", "c", "d" });
                test.Display();
    
    
                for (int vecnum = 0; vecnum < 4; vecnum++)
                {
                    var vector = test.GetVector(vecnum);
                    Console.Write($"vnum:{vecnum} :   ");
    
                    foreach (var value in vector)
                    {
                        Console.Write($"{value}   ");
                    }
                    Console.WriteLine("");
                }
    
            }
        }
    }

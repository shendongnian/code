    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            static void Main(string[] args)
            {
                Recursive(0, "");
            }
            static void Recursive(int index, string str)
            {
                for (int i = 0; i < characters.Length; i++)
                {
                    string newStr = str + characters[i];
                    if (index == 12)
                    {
                        Console.WriteLine(newStr);
                        Console.ReadLine();
                    }
                    else
                    {
                        Recursive(index + 1, newStr);
                    }
                }
            }
        }
     
    }

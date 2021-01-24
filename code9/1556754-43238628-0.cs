    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Threading.Tasks;
    namespace ConsoleApplication25
    {
   
     class Program
    {
        static char[] FloridaArray;
        static string DenverString;
        
        static void Main(string[] args)
        {
            //Increase Console Buffer Height
            Console.BufferHeight = Int16.MaxValue - 1;
            DenverString = ConvertStringArrayToString();
            FloridaArray = DenverString.ToArray();
            Console.WriteLine(DenverString);
            Console.WriteLine(FloridaArray[43]);
        }
        
        static string ConvertStringArrayToString()
        {
            // Concatenate all the elements into a StringBuilder.
            StringBuilder builder = new StringBuilder();
            foreach (var value in File.ReadAllLines("Labyrint.txt", Encoding.UTF8).Skip(1))
            {
                
                builder.Append(value);
                builder.AppendLine();
            }
            return builder.ToString();
           
        }
    }
     }

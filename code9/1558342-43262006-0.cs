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
        static List<string> wrd = new List<string>();
        static void Main(string[] args)
        {
            //Increase Console Buffer Height
            Console.BufferHeight = Int16.MaxValue - 1;
            DenverString = ConvertStringArrayToString();
           
            FloridaArray = DenverString.ToArray();
            Console.WriteLine(DenverString);
            
            for (int i = 0; i < DenverString.Length; i++)
            {
                if (FloridaArray[i] != '\n')
                {
                    wrd.Add(FloridaArray[i].ToString());
                    // Get character from array.
                    char letter = FloridaArray[i];
                    // Display each letter.
                    //Console.Write(i + " Letter: ");
                    //Console.WriteLine(letter);
                    
                   }
            }
            foreach (String o in wrd)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine(wrd[21]);
        }
        
        static string ConvertStringArrayToString()
        {
            // Concatenate all the elements into a StringBuilder.
            StringBuilder builder = new StringBuilder();
            foreach (var value in File.ReadAllLines("Labyrint.txt", Encoding.UTF8).Skip(1))
            {
               
                builder.Append(value);
               
                builder.Append('\n');
               
                //builder.Append(Environment.NewLine);
                //builder.AppendLine();
                //builder.Append("\r\n");
                //builder.Append("\r");
            }
            return builder.ToString();
           
        }
    }
     }

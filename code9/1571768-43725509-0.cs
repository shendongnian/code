    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Text.RegularExpressions;
    //(Program)
    namespace FileReader
    {
    class ReadFromFile
    {
        public static void IsValidLine(string text)
        {
            Regex rgx = new Regex(@"^([A-Za-z]{1,5})((\s\d){0,9})(\s*)$");
            if (rgx.IsMatch(text) == false)
            {
                Console.WriteLine("Invalid Format");
            }
    
        }
        static void Main()
        {
            System.IO.StreamReader file = new 
    System.IO.StreamReader(@"C:\Users\Public\TestFolder\WriteLines2.txt");
            {
                int counter = 0;
                string line;
                List<string> lines = new List<string>();
    
    
                while ((line = file.ReadLine()) != null)
                {
                    //HERE IS THE ERROR
                    IsValidLine(line); 
                    lines.Add(line);
                    counter++;
                }
            }
        }
    }

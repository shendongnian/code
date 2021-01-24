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
                string[] Names = new string[] { "Sangeen Khan", "AABY","AADLAND","LAND","LAND","SANG",
                "jh", "han", "ngee","SNOW","Jhon Snow","ADEMS","RONALDO"};
                //Names = Standardize(Names);
                string Text = @"I am Sangeen Khan and I am friend of AABY. Jhon is also friend of AABY.
                AADLAND is good boy and he never speak lie. AABY is also good. SANGEEN KHAN is my name.";
                //Text = Standardize(Text);
                List<string> matchedWords = Names.Where(Text.Contains).OrderBy(x => x.Length).Reverse().ToList(); //Prioritize longer matches... 
                matchedWords.ForEach(w => Text = Text.Replace(w, "Names")); //By replacing longer matched names first
                //listBox2.DataSource = matchedWords;
                int numMatchedWords = matchedWords.Count;
                Console.WriteLine("Matched Words: " + matchedWords.Aggregate((i, j) => i + " " + j));
                Console.WriteLine("Count: " + numMatchedWords);
                Console.WriteLine("Replaced Text: " + Text);
            }
        }
    }

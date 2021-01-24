    using System;
    using System.Text.RegularExpressions;
    namespace Regular
    {
        class Program
        {
            static void Main(string[] args)
            {
                string yourText = "this text has <b>weird < things</b> going on >";
                string newText = Regex.Replace(yourText, "</?[a-zA-Z][a-zA-Z0-9 \"=_-]*>", "");
                Console.WriteLine(newText);
            }
        }
    }

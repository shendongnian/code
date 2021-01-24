    using Microsoft.VisualBasic; // add reference
    using Microsoft.VisualBasic.CompilerServices;
    using System.Linq;
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main (string[] args)
            {
                string[] books = { "java 350", "Photoshop 225", "php 210", "JavaScript 80", "python 180", "jquery 250" };
                string input = "*" + string.Join ("*", "ph2".ToArray ()) + "*"; // will be *p*h*2*
                var matches = books.Where (x => LikeOperator.LikeString (x, input, CompareMethod.Text));
            }
        }
    }

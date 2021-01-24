    using System.Collections.Generic;
    using System.IO;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main (string[] args)
            {
                var filePath = "C:\\Users\\Core\\Desktop\\podaciC.txt";
                var result = new List<KeyValuePair<decimal, int>> (11000); // create list with initial capacity
                var lines = File.ReadLines (filePath); // allows to read file line by line (without loading entire file into memory)
                foreach (var line in lines)
                {
                    string[] splittedLine = line.Split (':'); // split line into array of two elements
                    decimal key = decimal.Parse (splittedLine[0]); // parse first element
                    int value = int.Parse (splittedLine[1]);       // parse second element
                    var kvp = new KeyValuePair<decimal, int> (key, value); // create tuple
                    result.Add (kvp);
                }
            }
        }
    }

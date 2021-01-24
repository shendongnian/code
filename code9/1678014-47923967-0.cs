     class Program
        {
            static void Main(string[] args)
            {
                List<string> textStorage = new List<string>();
    
                string exampleData = "Ford Mustang";
    
                Console.WriteLine(exampleData);
    
                SaveOutput(ref textStorage, exampleData);
    
                System.IO.File.WriteAllLines(@"C://Desktop//MyFolder", textStorage);
    
            }
            public static void SaveOutput(ref List<string> textStorage, string output)
            {
                textStorage.Add(output);
            }
        }

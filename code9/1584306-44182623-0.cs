    namespace TestConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string txt = File.ReadAllText(@"C:\Users\Public\TestFolder\test.txt");
                
                string[] lines = File.ReadAllLines(@"C:\Users\Public\TestFolder\test.txt");
                var reg = new Regex("\"");
    
                Console.WriteLine("Contents of test.txt are; ");
    
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
    
                    
                    var matches = reg.Matches(line);
                    foreach (var item in matches)
                    {
                        Console.WriteLine("Quotes at "+ ((System.Text.RegularExpressions.Capture)item).Index);
                    }
                }
            }
    
        }
    }

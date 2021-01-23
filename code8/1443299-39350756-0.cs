    class Program
    {
        static void Main(string[] args)
        {
            string[] linesArray = File.ReadAllLines(@"C:\Users\AK1\Desktop\CC2_B.TXT");
            int linecount = File.ReadAllLines(@"C:\Users\AK1\Desktop\CC2_B.TXT").Length;            
            List<string> outputLines = new List<string>();
            for (int i = 0; i < linecount; i++)
            {
                if (linesArray[i].Contains("2008/12"))
                {
                    string outputLine = "yes    " + linesArray[i];
                    outputLines.Add(outputLine);
                    Console.WriteLine(outputLine);
                }
                
            }
            Console.ReadLine();
        }
    }

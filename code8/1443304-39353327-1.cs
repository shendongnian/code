    class Program
    {
        static void Main(string[] args)
        {
            string[] linesArray = File.ReadAllLines(@"C:\Users\AK1\Desktop\CC2_B.TXT");
            int linecount = File.ReadAllLines(@"C:\Users\AK1\Desktop\CC2_B.TXT").Length;
            // Delcare your list here
            List<string> outputList = new List<string>();            
            for (int i = 0; i < linecount; i++)
            {
                if (linesArray[i].Contains("2008/12"))
                {
                    // You can "Add" to lists easily like this
                    outputList.Add(linesArray[i]);
                    // This will return you the last item in the list
                    string outputLine = "yes    " + outputList.Last();
                    Console.WriteLine(outputLine);
                }
            }
            // Then if you specifically want it back to an Array
            string[] outputArray = outputList.ToArray();
            Console.ReadLine();
        }
    }

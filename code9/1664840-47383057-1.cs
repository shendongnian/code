    class Program
    {
        static void Main(string[] args)
        {
            // this will read all lines from within the File
            // and automatically put them into an array
            //
            var linesRead = File.ReadLines("kiserlet.txt");
    
            // iterate through each element within the array and
            // print it out
            //
            foreach (var lineRead in linesRead)
            {
                Console.WriteLine(lineRead);
            }
        }
    }

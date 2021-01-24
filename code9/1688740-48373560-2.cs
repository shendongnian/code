    class Program
    {
        private static Random rnd = new Random();
        // Add whatever 'matrix' characters you want to print to the array below
        private static char[] matrixChars = new[] { '░', '▒', '▓', '█' };
        static string GetDottedLine(int density)
        {            
            var line = new StringBuilder();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                line.Append(rnd.Next(100) > density 
                    ? ' '  // Print a space to reduce density
                    : matrixChars[rnd.Next(matrixChars.Length)]); // Pick a random character
            }
            return line.ToString();
        }

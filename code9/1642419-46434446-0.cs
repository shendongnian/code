    static void Main(string[] args)
        {
            Console.WriteLine("Enter fully qualified path of the file to be accessed.");
            var eneteredPath = Console.ReadLine();
            var isItFile = Path.HasExtension(eneteredPath);
            if (isItFile)
            {
                Console.WriteLine($"Specified File exists = {File.Exists(eneteredPath)}");
            }
            else if(Directory.Exists(eneteredPath))
            {
                Console.WriteLine($"Specified path is to a directory.");
            }
        }

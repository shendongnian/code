      static void Main(string[] args)
        {
            SearchDirectory(@"c:\myFolder");
            Console.ReadKey();
        }
        static void SearchDirectory(string directory)
        {
            try
            {
                foreach (string file in Directory.GetFiles(directory))
                    Console.WriteLine(file);
                foreach (string directoryName in Directory.GetDirectories(directory))
                {
                    Console.WriteLine(directoryName);
                    SearchDirectory(directoryName);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

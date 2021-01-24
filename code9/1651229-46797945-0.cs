        static void Main(string[] args)
        {
            Regex pattern = new Regex("\"(.*?)\"");
            string file = @"C:\where\your-file\is\file.txt";
            using (StreamReader reader = File.OpenText(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    foreach (Match match in pattern.Matches(line))
                    {
                        Console.WriteLine(match.Value);
                    }
                }
            }
            Console.ReadLine();
        }

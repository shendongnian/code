        static void Main(string[] args)
        {
            string[] lines = File_ReadAllLines();
            List<string> words = new List<string>();
            foreach(var line in lines)
            {
                words.AddRange(line.Split(' '));
            }
            Console.WriteLine(words.Count);
        }
        private static string[] File_ReadAllLines()
        {
            return new[] {
                "The one book",
                "written by gnarf",
                "once upon a time ther werent any grammer",
                "iso 1-12122-445",
                "(c) 2012 under the hills"
            };
        }

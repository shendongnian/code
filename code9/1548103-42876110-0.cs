    class Program
    {
        public string word = "asd";
        public List<string> words = new List<string>();
    
        static void Main(string[] args)
        {
            var program = new Program();
            program.OpenFile();
            Debug.WriteLine(program.words.Count);
            program.anagram();
    
        }
    
        public void OpenFile()
        {
    
            using (var fileStream = File.OpenRead("wordlist.txt"))
            using (var streamReader = new StreamReader(fileStream))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    this.words.Add(line);
                }
    
            }
    
        }
    
        public void anagram()
        {   
            Console.WriteLine(this.word);
        }
    
    }

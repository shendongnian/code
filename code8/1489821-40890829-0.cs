       static void Main(string[] args) {
         // better practice is paths combining
         string path = Path.Combine(Environment.SpecialFolder.Desktop, "list.txt");
         // unique (no duplicates) strings so far
         HashSet<String> hash = new HashSet<string>(
           File.ReadLines(path), // file to read from
           StringComparer.OrdinalIgnoreCase); // let's ignore words' case
    
         Console.WriteLine("New Word: ");
    
         string newWord = Console.ReadLine().Trim(); // let's trim spaces
    
         if (!string.IsNullOrEmpty(newWord)) // let's not add an empty string
           if (!hash.Contains(newWord)) {
             File.AppendAllLines(path, new string[] {newWord});
    
             Console.WriteLine("New word has been added! ");
           } 
         Console.ReadKey();
       }

    Console.WriteLine("Please enter a filename:");
    var theFile = Console.ReadLine();
    
    var delim = " ,.".ToCharArray();
    var countWords = new[] { "Jude" }.Select(w => w.ToLower()).ToHashSet();
    var count = File.ReadLines(theFile).Select(l => l.Split(delim, StringSplitOptions.RemoveEmptyEntries).Count(w => countWords.Contains(w.ToLower()))).Sum();
    Console.WriteLine("The word count is {0}", count);

    static void Main(string[] args)
    {
        string file = "E:\\Project_PU.txt";
        // This will hold the path value
        string path = null;
        // Get all the file lines into an array
        string[] fileLines = File.ReadAllLines(file);
        // Find all the lines that begin with 'Path='
        List<string> pathLines = fileLines.Where(l => l.StartsWith("Path=")).ToList();
        // If we found any lines, get the first one that has a valid path
        if (pathLines != null && pathLines.Any())
        {
            // Get the first entry that begins with 'Path=' and ends with a valid file path
            path = pathLines
                .FirstOrDefault(l => File.Exists(l.Substring(l.IndexOf("=") + 1)));
            if (path != null) path = path.Substring(path.IndexOf("=") + 1);
        }
        // If there was no path specified, then prompt the user to enter one
        if (string.IsNullOrEmpty(path))
        {
            Console.Write("Please enter the path: ");
            path = Console.ReadLine();
        }

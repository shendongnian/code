    static void Main(string[] args)
    {
        string file = "E:\\Project_PU.txt";
        // This will hold the path value
        string path = null;
        // Get all the file lines into an array
        string[] fileLines = File.ReadAllLines(file);
        // Find the first line that starts with 'Path='
        string pathLine = fileLines.FirstOrDefault(l => l.StartsWith("Path="));
        // If we found the line, get the substring starting after the '='
        if (pathLine != null)
        {
            path = pathLine.Substring(pathLine.IndexOf("=") + 1);
        }
        // If there was no path specified, then prompt the user to enter one
        if (string.IsNullOrEmpty(path))
        {
            Console.Write("Please enter the path: ");
            path = Console.ReadLine();
        }

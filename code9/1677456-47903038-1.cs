    // Define regex matching your requirement
    Regex g = new Regex(@"hostname:\s+(\.+?)"); // Matches "hostname:<whitespaces>SOMETEXT" 
                                                // Capturing SOMETEXT as the first group
    using (var sr = File.OpenText(path))
    {
        string line;
        while ((line = sr.ReadLine()) != null) // Read line by line
        {
            Match m = g.Match(line);
            if (m.Success)
            {
                // Get value of first capture group in regex
                string v = m.Groups[1].Value;
                // Print Captured value , 
                // (interpolated string format $"{var}" is available in C# 6 and higher)
                Console.WriteLine($"hostname is {v}"); 
                break; // exit loop if value has been found
                       // this makes only sense if there is only one instance
                       // of that line expected in the file.
            }
        }
    }

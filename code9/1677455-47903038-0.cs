    // Define regex matching your requirement
    Regex g = new Regex(@"hostname:\s+(\.+?)"); // Matches "hostname:<whitespaces>SOMETEXT" Capturing SOMETEXT 
    using (var sr = File.OpenText(path))
    {
        string line;
        while ((line = sr.ReadLine()) != null) // Read line by line
        {
            Match m = g.Match(line);
            if (m.Success)
            {
                string v = m.Groups[1].Value;
                Console.WriteLine($"hostname is {v}"); // Print Captured value
                break; // exit loop if value has been found
            }
        }
    }

    var sr = new StreamReader(filepath);
    string[] header = null;
    while (true)
    {
        var line = sr.ReadLine();
        if (line == null)
            break; // End of file
        var lineParts = line.Split(" .".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        if (header == null)
        {
            // save first line
            header = lineParts;
            // now header[13] is equal "MTC1"
        }
        else
        {
            // process other lines by one
        }
    }

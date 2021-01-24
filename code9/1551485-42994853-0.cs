    // Read all lines from text file.
    String[] lines = File.ReadAllLines("path to file");
    for(int i = 3; i <= 5; i++) // From line 3 to line 5
    {
        // Replace 'no' to 'number' in 3 - 5 lines
        lines[i - 1] = lines[i - 1].Replace("no", "number");
    }
    // Rewrite lines to file
    File.WriteAllLines("path to file", lines);

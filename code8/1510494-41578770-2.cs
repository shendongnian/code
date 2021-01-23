    IEnumerable<String> lines = File.ReadLines("c:\myfile.txt", new UTF8Encoding());
    
    StringBuilder sb = new StringBuilder();
    string previousLine = null;
    int lineCounter = 0;
    int totalLines = lines.Count();
    foreach (string line in lines) {
        // show progress
        float done = ++lineCounter/totalLines;
        Debug.WriteLine($"{done*100:0.00}% complete");
        //get the line and do something
        sb.AppendLine(line);
    
        //do something else, like look at the previous line to compare
        if (line == previousLine) {
            Debug.WriteLine($"Line {lineCounter} is the same as the previous line.");
        }
        previousLine = line;
    }

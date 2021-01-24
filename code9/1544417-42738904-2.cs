    // Where we store the lines loaded from file
    List<string> lines = new List<string>();
    // Read a block of 10MB
    char[] buffer = new char[1024 * 1024 * 10];
    bool lastBlock = false;
    string leftOver = string.Empty;
    // Start the streamreader
    using (StreamReader reader = new StreamReader(@"D:\temp\localtext.txt"))
    {
        // We exit when the last block is reached
        while (!lastBlock)
        {
            // Read 10MB
            int loaded = reader.ReadBlock(buffer, 0, buffer.Length);
            // Exit if the file size is exactly a multiple of 10MB
            if(loaded == 0) break;
            // if we get less bytes then we have loaded everything
            lastBlock = (loaded != buffer.Length || loaded == 0);
            
            // Create the string from the buffer
            string temp = new string(buffer, 0, loaded);
            
            // prepare the working string adding the remainder from the 
            // previous loop
            string current = leftOver + temp;
            // Search the last \r\n
            int lastNewLinePos = temp.LastIndexOf("\r\n");
            if (lastNewLinePos > -1)
            {
                 // Prepare the working string
                 current = leftOver + temp.Substring(0, lastNewLinePos + 2);
                 // Save the incomplete parts for the next loop
                 leftOver = temp.Substring(lastNewLinePos + 2);
            }
            // Process the lines
            AddLines(current, lines);
        }
    }
    
    void AddLines(string current, List<string> lines)
    {
        var splitted = current.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        lines.AddRange(splitted.Select(x => x.Replace("\n", " ")).ToList());
    }

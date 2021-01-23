    List<string> linesInFile = File.ReadAllLines(filePath).ToList(); // gives you list of lines
    string input = "line 3";
    int lineIndex = linesInFile.IndexOf(input);
    if (lineIndex != -1)
    {
        linesInFile.RemoveAt(lineIndex);
    }
    // If you may have more number of match for particular line means you can try this as well :
    linesInFile.RemoveAll(x=> x== input);

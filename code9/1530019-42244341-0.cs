    string[] xmlLines = File.ReadAllLines(path);    
    int linesFrom = 5;
    int exceptionLine = 10; //Your  line number
    int startLine = exceptionLine - linesFrom - 1 > 0 ? exceptionLine - linesFrom - 1: 0;
    int endLine = exceptionLine + linesFrom - 1 > xmlLines.Count - 1 ? exceptionLine + linesFrom  - 1: xmlLines.Count - 1;
    StringBuilder sb = new StringBuilder();
    for (int i = startLine ; i < endLine ; i++)
    {
        sb.Append(xmlLines[i]);
    }
    return sb.ToString();

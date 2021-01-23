    class CppFunction
    {
        public string FunctionName { get; set; }
        public int StartLine { get; set; }
        public int EndLines { get; set; }
    }
    List<CppFunction> AnalyzeCpp(string path)
    {
        List<CppFunction> lstCppFunc = new List<CppFunction>();
        IEnumerable<string> loc = File.ReadLines(path, encode);
        string[] locNoCom = RemoveComment(loc);
        RemoveIfdefineDebug(locNoCom);
        int level = 0;
        CppFunction crtFunc = null;
        int lineCount = 0;
        StringBuilder builder = new StringBuilder();
        bool startName = false;
        string builderToString;
        string lastLine = "";
        foreach (string line in locNoCom)
        {
            lineCount++;
            if (string.IsNullOrWhiteSpace(line))
            {
                lastLine = line;
                continue;
            }
            if (level <= 0)
            {
                if (line.Contains('('))
                {
                    crtFunc = new CppFunction();
                    if (line.Trim().IndexOf('(') == 0)
                        builder.Append(lastLine);
                    builder.AppendLine(line);
                    crtFunc.StartLine = lineCount;
                    startName = true;
                }
                if (startName)
                {
                    builderToString = builder.ToString();
                    if (line != builderToString.Replace("\r\n",string.Empty))
                        builder.AppendLine(line);
                    if (line.Contains(')'))
                    {
                        startName = false;
                        if (crtFunc != null)
                            crtFunc.FunctionName = builder.ToString();
                        builder.Clear();
                    }
                }
            }
            if(line.Contains('{'))
            {
                foreach(char c in line)
                {
                    if (c == '{')
                        level++;
                }
            }
            if(line.Contains('}'))
            {
                foreach (char c in line)
                {
                    if (c == '}')
                        level--;
                }
                if (crtFunc != null && level <= 0)
                {
                    crtFunc.EndLines = lineCount;
                    lstCppFunc.Add(crtFunc);
                    crtFunc = null;
                    level = 0;
                }
            }
            lastLine = line;
        }
        return lstCppFunc;
    }

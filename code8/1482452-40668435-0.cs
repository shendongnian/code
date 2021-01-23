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
        int level = 0;
        CppFunction crtFunc = null;
        int lineCount = 0;
        StringBuilder builder = new StringBuilder();
        bool startName = false;
        string builderToString;
        foreach(string line in loc)
        {
            lineCount++;
            if (level == 0)
            {
                if (line.Contains('('))
                {
                    crtFunc = new CppFunction();
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
                if (crtFunc != null && level == 0)
                {
                    crtFunc.EndLines = lineCount;
                    lstCppFunc.Add(crtFunc);
                    crtFunc = null;
                }
            }
        }
        return lstCppFunc;
    }

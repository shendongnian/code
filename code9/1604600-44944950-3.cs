    int lineNumber = 0;
    var _replacementInfo = new Dictionary<int, List<string>>();
    using (StreamReader sr = new StreamReader(logF))
    {
        using (StreamWriter sw = new StreamWriter(logF_Temp))
        {
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                lineNumber++;
                foreach (var kv in replacements)
                {
                    bool contains = line.Contains(kv.Key);
                    if (contains)
                    {
                        List<string> lineReplaceList;
                        if (!_replacementInfo.TryGetValue(lineNumber, out lineReplaceList))
                            lineReplaceList = new List<string>();
                        lineReplaceList.Add(kv.Key);
                        _replacementInfo[lineNumber] = lineReplaceList;
                        line = line.Replace(kv.Key, kv.Value);
                    }
                }
                sw.WriteLine(line);
            }
        }
    }

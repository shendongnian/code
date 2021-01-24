    int lineNumber = 0;
    using (StreamReader sr = new StreamReader(logF))
    {
      using (StreamWriter sw = new StreamWriter(logF_Temp))
      {
         while (!sr.EndOfStream)
         {
            string line = sr.ReadLine();
            lineNumber++;
            foreach(var kv in replacements)
            {
                bool contains = line.Contains(kv.Key);
                if(contains)
                     _replacementInfo.Add(lineNumber, kv.Key);
                line = line.Replace(kv.Key, kv.Value);
            }
            sw.WriteLine(line);
         }
      }
    }

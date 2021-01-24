    using (StreamReader sr = new StreamReader(logF))
    {
      using (StreamWriter sw = new StreamWriter(logF_Temp))
      {
         while (!sr.EndOfStream)
         {
            string line = sr.ReadLine();
            foreach(var kv in replacements)
                line = line.Replace(kv.Key, kv.Value);
            sw.WriteLine(line);
         }
      }
    }

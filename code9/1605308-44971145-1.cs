    string line = string.Empty;
    Dictionary<string, int> found = new Dictionary<int, string>();
    using(System.IO.StreamReader file = new System.IO.StreamReader(@"c:\Path\To\BigFile.txt"))
    {
       while(!file.EndOfStream)
       {
          line = file.ReadLine();
          // Matches found logic
          if (!found.ContainsKey(line)) found.Add(line, 1);
          else found[line] = found[line] + 1;
        }
    }

    IEnumerable<Symbol> SymbolsFromFolder(string file)
    {
        string[] lines = File.ReadAllLines(file);
        for (int i = 0; i < lines.Length-1; i++)
        {
            string line = lines[i];
            if (line.Contains("inst"))
            {
                yield return new Symbol(line, lines[i + 1], i + 1);
            }
        }
    }

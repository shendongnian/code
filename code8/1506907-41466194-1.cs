    private IEnumerable<Symbol> _getSymbolsFromFile(string fileName)
    {      
          string[] lines = File.ReadAllLines(fileName);
          for (int i = 0; i < lines.Length; i++)
          {
              string line = lines[i];
              if (line.Contains("inst"))
                  yield return new Symbol(line, lines[i + 1], i + 1);
          }
    }

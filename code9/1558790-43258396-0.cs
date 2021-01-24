    private Parse(string lines)
    {
      const int secondColumn = 1;
      const int thirdColum = 2;
      string [] arrlines = lines.Split('\r');
      foreach (string line in arrlines)
      {
        string [] numbers = line.Split('|');
        var secondNumberFinal = Int32.Parse(numbers[secondNumbers]);
        var thirdNumberFinal = Int32.Parse(numbers[thirdNumbers]);
        // Whatever you want to do with them here
      }
    }

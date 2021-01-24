    private static void displayData<T>(string text, Dictionary<string, T> dict)
    {
      string words = "The " + text + " Dictionary contains the following:";
      Console.Out.WriteLine(words);
      foreach (var pair in dict)
      {
        Console.Out.WriteLine(pair.Key + "=>" + pair.Value.ToString());
      }
      Console.Out.WriteLine("");
    }

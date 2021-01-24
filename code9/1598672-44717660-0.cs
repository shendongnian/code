      Dictionary<string, int> jokes = new Dictionary<string, int>(
        StringComparer.OrdinalIgnoreCase) {
          { "question1", 3 },
          { "question2", 4 },
          { "question3", 2 },
          .... 
        };
      ...
      int randMax = 0;
      if (jokes.TryGetValue(Console.ReadLine(), out randMax)) {
        Console.Clear();
        randIndex = rand.Next(0, randMax);
        Console.WriteLine(state[randIndex]);
        Discussion();
      }

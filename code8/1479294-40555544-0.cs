    private static List<Tuple<int, int>> s_Points = new List<Tuple<int, int>>();
    private static void UserInput() {
      while (true) {
        string input = Console.ReadLine().Trim(); // be nice, let " stop   " be accepted
        if (string.Equals(input, "stop", StringComparison.OrdinalIgnoreCase))
          return;
        // let be nice to user: allow he/she to enter a point as 1,2 or 3   4 or 5 ; 7 etc.
        string[] xy = input.Split(new char[] { ',', ' ', ';', '\t' },
                                  StringSplitOptions.RemoveEmptyEntries);
        int x = 0, y = 0;
        if (xy.Length == 2 && int.TryParse(xy[0], out x) && int.TryParse(xy[1], out y)) 
          s_Points.Add(new Tuple<int, int>(x, y));
        else
          Console.WriteLine($"{input} is not a valid 2D point.");
      }
    }

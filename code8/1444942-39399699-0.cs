      class Program
      {
        static void Main(string[] args)
        {
    
          string results = " A 1 B 0, A 2 C 4, A 1 D 8, A 5 E 9";
    
          string[] matches = results.Trim().Split(',');
    
          List<Match> sportResults = new List<Match>();
          foreach (string match in matches)
          {
            string[] parts = match.Trim().Split(null);
    
            sportResults.Add(new Match() {
              Team1 = parts[0], Score1 = int.Parse(parts[1]),
              Team2 = parts[2], Score2 = int.Parse(parts[3])});
    
          }
    
          sportResults.ForEach(a => Console.WriteLine(a));
        }
      }

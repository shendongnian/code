    class Match
      {
        public string Team1 { get; set; }
        public string Team2 { get; set; }
    
        public int Score1 { get; set; }
        public int Score2 { get; set; }
    
        public override string ToString()
        {
          return "Team " + Team1 + " " + Score1 + " VS " + Team2 + " " + Score2;
        }
      }

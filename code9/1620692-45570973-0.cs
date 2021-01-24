    public class Lineup
    {
        public int LineupID { get; set; }
        public int PlayerID { get; set; }
        public ICollection<Player> Attendants { get; set; } = new List<Player>();
    }

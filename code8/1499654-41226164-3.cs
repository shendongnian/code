    public absrtact class Game
    {
        public string Wins { get; set; }
        public int Lost { get; set; }
        public string Played { get; set; }
    }
    public class Quick : Game // note that Quick game has Lost and PLayed now!
    {
    }
    public class Competitive : Game
    {
    }

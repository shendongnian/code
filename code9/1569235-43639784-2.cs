    public final TennisPlayer : Player
    {
      public override Sport Sport => Sport.Tennis;
      public double Rating { get; set; }
      public int ServeSpeed { get; set; }
      public TennisPlayer(string name, DateTime birthday, double rating, int speed) : base(name, birthday) 
      {
        this.Rating = rating;
        this.ServeSpeed = speed;
      }
      public override string ToString() 
      {
        return @"Tennis player: {Name} {Birthday} {Rating} {ServeSpeed}";
      }
    }

    public sealed class TennisPlayer : Player
    {
      public override Sport Sport => Sport.Tennis;
      // Again, do these change after construction? If not
      // then remove the setters.
      public decimal Rating { get; set; }
      public int ServeSpeed { get; set; }
      public TennisPlayer(string name, DateTime birthday, decimal rating, int speed) : base(name, birthday) 
      {
        this.Rating = rating;
        this.ServeSpeed = speed;
      }
      public override string ToString() 
      {
        return @"Tennis player: {Name} {Birthday} {Rating} {ServeSpeed}";
      }
    }

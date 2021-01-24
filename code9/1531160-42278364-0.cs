    public enum Ratings
    {
      Fm,  // F-
      F,   // F
      Fp,  // F+
      Em,  // E-
      E,   // E
      Ep,  // E+
      Dm,  // D-
      D,   // D
      Dp,  // D+
      Cm,  // C-
      C,   // C
      Cp,  // C+
      Bm,  // B-
      B,   // B
      Bp,  // B+
      Am,  // A-
      A,   // A
      Ap   // A+
    }
    public class User
    {
      public string Name { get; set; }
      public Ratings Rating { get; set; }
      public User(string name, Ratings rating)
      {
        Name = name;
        Rating = rating;
      }
    }
    ...
    var user1 = new User("Joe", Ratings.Bp);
    var user2 = new User("Alex", Ratings.D);
    if (user1.Rating > user2.Rating)
      ...

    public static readonly String[] Messages =
    {
        "Person is the winner",
        "Person is the looser",
        "Game is tied"
    };
    public enum GameOver
    {
        Winner = 0,
        Looser = 1,
        Tied = 2
    }
    Display(Messages[(Int32)GameOver.Winner]);

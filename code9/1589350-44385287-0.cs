    private int plays;
    private int rounds;
    private void Start()
    {
        plays = 0;
        rounds = 0;
        StartCoroutine(gamePlay());
    }
    public void NextBall()
    {
        plays++;
        // Here you can change the logic behind the 2 balls
        // (I remember it changes depending on whether you did a strike or not, if it's your last play or not, ...)
        if (plays >= 2)
        {
            plays = 0;
            rounds++;
            StartCoroutine(gamePlay());
        }
    }
    public IEnumerator gamePlay()
    {
        // This is based on player 1 being the first player
        pl1.hasPlay = (rounds % 2 == 0);
        pl2.hasPlay = !pl1.hasPlay;
             
        pl1.gameObject.SendMessage(pl1.hasPlay ? "Activate" : "Deactivate");
        pl2.gameObject.SendMessage(pl2.hasPlay ? "Activate" : "Deactivate");
        yield return 0;
    }

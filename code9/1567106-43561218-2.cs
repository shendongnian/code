    public static void diceTeam(out string p1)
    {
        Random rnd = new Random();
        for (int i = 0; i < 5; i++)
        {
            if (i == 1)
            {
                //Random rnd = new Random();
                p1 = rnd.Next().ToString();
            }
            else if (i == 2)
            {
                //Random rnd = new Random();
                rnd.Next();
            }
            else if (i == 3)
            {
                //Random rnd = new Random();
                rnd.Next();
            }
            else if (i == 4)
            {
                //Random rnd = new Random();
                rnd.Next();
            }
            else if (i == 5)
            {
                //Random rnd = new Random();
                rnd.Next();
            }
        }
        p1 = "";
    }

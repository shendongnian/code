    public static string diceTeam()
    {
        Random rnd = new Random();
        var res = "";
        for (int i = 0; i < 5; i++)
        {
            if (i == 1)
            {
                //Random rnd = new Random();
                res += rnd.Next().ToString();
            }
            else if (i == 2)
            {
                //Random rnd = new Random();
                res += rnd.Next().ToString();
            }
            else if (i == 3)
            {
                //Random rnd = new Random();
                res += rnd.Next().ToString();
            }
            else if (i == 4)
            {
                //Random rnd = new Random();
                res += rnd.Next().ToString();
            }
            else if (i == 5)
            {
                //Random rnd = new Random();
                res += rnd.Next().ToString();
            }
        }
        return res;
    }

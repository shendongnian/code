    public void TrySomething(int sec)
    {
        DateTime endTime = DateTime.Now.AddSeconds(sec);
        while (DateTime.Now < endTime)
        {
             // do useful stuff
        }
    }

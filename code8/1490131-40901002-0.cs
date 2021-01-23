    public IEnumerable<string> GetPlayTimes()
    {
        int i = 0;
        do
        {
            i++;
            //Start is the starting time, say 11:45 am
            start = start.AddMinutes(90);
            yield return start.ToShortTimeString();
        } while (i < totalSessions); //totalSessions is the result of hours / 1.5
    }

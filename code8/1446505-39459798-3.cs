    [Flags]
    public enum Levels 
    {
        Level01 = 1, /* note values are powers of 2*/
        Level02 = 2,
        Level03 = 4,
        Level04 = 8
    }
    void OnTriggerEnter2D (Collider2D Ball)
    {
        EndGame.SetActive(true);
        WinStar.SetActive(true);
        /* Note enum value can be calculated as 2^Level 
           May want to internalize logic in method on PlayerPrefs class */
        PlayerPrefs.LevelState |= (int) Math.Pow(2, CurrentLevel);
        deactive();
        COuntAndTime();
        /* new method for determining TotalStars 
           May want to internalize logic in method on TotalStars Class */
        TotalStars.Totalstars = CountBits(PlayerPrefs.LevelState); 
        //this value should increase only once for each objective in each level.
        TotalStars.totstar.Save();
    }
    /* Method modified from http://stackoverflow.com/questions/12171584/what-is-the-fastest-way-to-count-set-bits-in-uint32-in-c-sharp 
    Counts the number of set bits in Levels */
    public static int CountBits(Levels value)
    {    
        int count = 0;
        while (value != 0)
        {
            count++;
            value &= value - 1;
        }
        return count;
    }

    GameObject[] yourItem = null;
    bool firstRun = true;
    int lastRandomNum = 0;
    
    void Update()
    {
        if (firstRun)
        {
            firstRun = false;
            //First run, use Random.Range
            lastRandomNum = UnityEngine.Random.Range(0, yourItem.Length);
        }
        else
        {
            //Not First run, use RandomWithExclusion
            lastRandomNum = RandomWithExclusion(0, yourItem.Length, lastRandomNum);
        }
    
        //Do something with the lastRandomNum value below
       
        newBall = theObjectballPools[lastRandomNum].GetPooledObject();
    }
    
    int RandomWithExclusion(int min, int max, int exclusion)
    {
        var result = UnityEngine.Random.Range(min, max - 1);
        return (result < exclusion) ? result : result + 1;
    }

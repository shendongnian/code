    int lastValue;
    public int UniqueRandomInt(int min, int max)
    {
        int val = Random.Range(min, max);
        while(lastValue == val)
        {
            val = Random.Range(min, max);
        }
        lastValue = val;
        return val;
    }
    void Update() 
    {
        UniqueRandomInt(1, 4);
        Inst();
    }
    void Inst()
    {
        if (lastValue == 1)
        {
            //instantiate obj1
        }
        else if (lastValue == 2)
        {
            //instantiate obj2
        }
        else if (lastValue == 3)
        {
            //instantiate obj3
        }
    }

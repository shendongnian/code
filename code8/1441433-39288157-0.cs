    public void Dec(int? t) 
    {
        if (t != null) 
        {
            t--; //if initial t == 50, then after this t == 49.
        }
    }
    ...
    int? t = 50;
    Dec(t); // but here t is still == 50

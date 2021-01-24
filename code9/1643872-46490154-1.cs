    public int achievement1 = 0;
    private float _score;
    
    public float score
    {
        get
        {
            return _score;
        }
    
        set
        {
            if (_score != value)
            {
                _score = value;
    
                if (score >= achievement1)
                {
                    //Do something
                }
            }
        }
    }

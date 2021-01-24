    public int Age
    {
        get { return age; }
        set
        {
            age = value;
            Debug.Assert(age == value);
        }
    }

    public bool IsScreening
    { 
        get { return TestTypeRef == 0; }
        set { if (value) TestTypeRef = 0; }
    }
    public bool IsFull
    { 
        get { return TestTypeRef == 1; }
        set { if (value) TestTypeRef = 1; }
    }

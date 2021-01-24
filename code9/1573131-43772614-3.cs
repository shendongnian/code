    // Read-only property
    public int TotalFaceValue
    {
        get { return _cards.Sum(c => c.facevalue); }
    }
    // Method
    public int GetTotalFaceValue()
    {
        return _cards.Sum(c => c.facevalue);
    }

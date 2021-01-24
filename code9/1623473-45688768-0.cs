    public int MyNumber { get; }
    public void SetNumber()
    {
        Randon rnd = new Random();
        MyNumber = rnd.Next(1,13);
    }

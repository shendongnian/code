    public int MyNumber { get; private set; }
    public void SetRandomNumber()
    {
        Random rnd = new Random();
        MyNumber = rnd.Next(1,13);
    }

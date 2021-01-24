    private int myNum;
    public String MyNumber
    {
        get { return myNum };
        set { DoSomething(); }
    }
    DoSomething()
    {
        Randon rnd = new Random();
        myNum = rnd.Next(1,13);
    }

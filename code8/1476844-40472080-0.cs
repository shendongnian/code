    private int _id;
    public String ID { get { return int _id; } set { int _id = value; } }
    public void Test()
    {
        Int32.TryParse("Sausage Factory", out _id);
    }

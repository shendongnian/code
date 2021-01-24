    ctor(string someNumberString)
    {
        Month = Convert.ToInt32(someNumberString.Substring(2, 2));
    }
    public Month { get; }

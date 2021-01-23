    public interface IExample
    {
        int GetInt();
    }
    public void ProcessInt(IExample value)
    {
        var tempInt = value.GetInt();
        // Do processing here
    }

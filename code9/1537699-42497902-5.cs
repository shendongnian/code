    public interface IMyQuery
    {
        [Cache(60000)]
        string GetName();
    }
    public interface IMySecondQuery
    {
        [Cache(1000)]
        string GetSecondName();
    }

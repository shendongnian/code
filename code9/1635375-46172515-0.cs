    interface IExistingReadWrite : IRead
    {
        int width { get; set; }
    }
    interface IRead
    {
        int width { get; }
    }

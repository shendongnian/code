    interface IExistingReadWrite : IRead
    {
        // Use IWrite interface instead if you require write only.
        int width { get; set; }
    }
    interface IRead
    {
        int width { get; }
    }
    public interface IWrite
    {
        int width {set; }
    }

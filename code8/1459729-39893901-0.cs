    public interface IStuff
    {
        IsExpanded { get; set; }
    }
    public interface IStuff<T> : IStuff
    {
        IList<T> Items { get; set; }
    }

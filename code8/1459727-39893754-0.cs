    public interface IStuff<out T>
    {
        IList<T> Items { get; set; }
        IsExpanded { get; set; }
    }

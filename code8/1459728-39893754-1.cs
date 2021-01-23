    public interface IStuff<out T>
    {
        IEnumerable<T> Items { get; set; }
        bool IsExpanded { get; set; }
    }

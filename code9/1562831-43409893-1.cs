    [ComVisible(true)]
    public interface ICars
    {
        int Count { get; }
        ICar this[int index] { get; }
    }

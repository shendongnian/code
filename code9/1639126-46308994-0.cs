    public interface IGroup<T>
    {
        IGroup<T> Group { get; }
        IFolder<T> Folder { get; }
    }
    public interface IFolder<T>
    {
        T Build();
    }

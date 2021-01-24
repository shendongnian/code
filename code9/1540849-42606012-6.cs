    public interface IMyTable<T>
    {
        string Name { get; set; }
        T GetAll();
    }

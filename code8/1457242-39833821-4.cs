    public interface IUnit<T>
    {
        string Name { get;}
        void SetContainer(T t);
        bool Rename(String newName);   
    }
    public interface IContainer
    {
       bool IsNameBusy(String newName);
       int Count { get; }
    }

    public interface IMember
    {
        bool IsGroup { get; }
    }
    public interface IUser : IMember { }
    public interface IGroup: IMember
    {
        IEnumerable<IMember> Members { get; }
    }

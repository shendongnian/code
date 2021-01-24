    public interface IMyNewCrudRepository<T, TId> : 
        ICreatableRepository<T>,
        IReadableRepository<T, TId>,
        IUpdatableRepository<T>,
        IDeletableRepository<TId>
    {}

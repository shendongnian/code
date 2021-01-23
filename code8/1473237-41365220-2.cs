    public interface IMongoObserver<TCollection>
    {
        void OnPropertyChanged<TField>(Expression<Func<TCollection, TField>> func, TField value);
        UpdateDefinition<TCollection> Definition { get; }
    }
    public interface IMongoSelector<TCollection>
    {
        FilterDefinition<TCollection> Definition { get; }
    }

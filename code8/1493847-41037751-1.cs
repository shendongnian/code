    // No more PayLoad generic type parameter! Let's move it to
    // the methods
    public interface IReceiver
    {
        string Name { get; }
        Task SendObjectContainerAsync<TPayLoad>(ObjectContainer<TPayLoad> m);
        Task<ObjectContainer<TPayLoad>> GetSnapshot<TPayLoad>();
    }

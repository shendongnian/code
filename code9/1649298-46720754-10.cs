    public interface IWhen<T> {
        IThen<T> Then(Action<T> action);
    }
    public interface IThen<T> : IRun {
        IWhen<T> When(Func<T, bool> test);
        IRun Otherwise(Action<T> action);
    }
    public interface IRun {
        void Run();
    }
    public interface IRule<T> {
        Func<T, bool> Predicate { get; }
        Action<T> Invoke { get; }
    }

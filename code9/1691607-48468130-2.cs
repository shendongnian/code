    public abstract class Asset<T>  where T : IController
    {
        ...
        public T Controller { get; set; }
        ...
    }
    public interface IController
    {
        void ContollerMethod();
    }

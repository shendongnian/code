    public interface IOwned<T> : IDisposable
    {
        T Value { get; }
    }
    public class MyOwned<T> : IOwned<T>
    {
        public MyOwned(Owned<T> owned)
        {
            this._owned = owned;
        }
        private readonly Owned<T> _owned;
        public virtual T Value
        {
            get
            {
                return this._owned.Value;
            }
        }
        public void Dispose()
        {
            this._owned.Dispose();
        }
    }

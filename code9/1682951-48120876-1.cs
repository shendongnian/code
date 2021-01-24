    internal abstract class B : IDisposable
    {
        public void Dispose()
        {
            DisposeImpl();
        }
        protected abstract void DisposeImpl();
    }
    internal sealed class A : B
    {
        protected override void DisposeImpl()
        {
            //TODO.
        }
    }

    internal abstract class A : IDisposable
    {
        public void Dispose()
        {
            DisposeImpl();
        }
        protected abstract void DisposeImpl();
    }
    internal sealed class B : A
    {
        protected override void DisposeImpl()
        {
            //TODO.
        }
    }

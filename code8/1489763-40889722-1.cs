    public sealed class DisposingFinisher : IDisposable
    {
        readonly IDisposableThingWithFinish _item;
        public Disposing(IDisposableThingWithFinish item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            _item = item;
        }
        public void Dispose()
        {
            try
            {
                _item.Finish();
            }
            finally
            {
                _item.Dispose();
            }
        }
    }

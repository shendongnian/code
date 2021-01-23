    public sealed class ManagedResourceClient : IDisposable
    {
        private ITheManagedResource _myManagedResource = new TheManagedResource()
        public void Dispose()
        {
            if ( _myManagedResource != null )
            {
                _myManagedResource.Dispose();
                _myManagedResource = null;
            }
        } 
    }

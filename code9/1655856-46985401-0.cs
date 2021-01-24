    public sealed class OwnersX : IEnumerable<Owner>
    {
        private IEnumerable<Owner> owners;
    
        public IEnumerator<T> GetEnumerator()
        {
            return owners.GetEnumerator();
        }
    }

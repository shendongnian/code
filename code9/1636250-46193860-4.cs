    public class yourClass<T>  where T : class, IMax
    {
        public int GetMaxPK(IEnumerable<T> yourTable)
        {
            var GetMaxId = yourTable.Max(c => c.Id);
            return GetMaxId;
        }
    }

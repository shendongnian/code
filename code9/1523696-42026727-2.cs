    class Comparer : IEqualityComparer<Transaction>
    {
        public bool Equals(Transaction x, Transaction y)
        {
            return x.TransactionID == y.TransactionID;
        }
        public int GetHashCode(Transaction obj)
        {
            return obj.TransactionID.GetHashCode();
        }
    }

    internal abstract class StaticTransaction<T> : BaseTransaction<T>
    where T : class, ITransaction, new()
    {
        public StaticTransaction()
        {
            OpcClient = new T();
        }
    }

    public class TableFactory : ITableFactory
    {
        public ITable NewTable(string name)
        {
            return new Table(name);
        }
    }

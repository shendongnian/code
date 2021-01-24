    public interface ITableFactory
    {
        ITable NewTable(string name);
    }
    public class TableManager
    {  
        private ITableFactory factory;
        public TableManager(ITableFactory factory)
        {
            this.factory = factory;
        }
        public void addTable(string name)
        {
            _tableDict[name] = factory.NewTable(name);
        }
        /* the rest of your code */
    }

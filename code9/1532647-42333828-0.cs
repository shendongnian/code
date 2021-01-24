    abstract class BaseGateway<T> : IDefaultGateway<T> where T : IDataTransferObject
    {
        readonly string _tableName;
        readonly string _selectAll;
        public BaseGateway()
        {
            // default table name
            _tableName = this.GetType().Name.Replace("DTO", "");
            _selectAll = $"select * from {_tableName}";
        }
        // these members are virtual, so that they can be overriden
        protected virtual string TableName => _tableName;
        protected virtual string SelectAll => _selectAll;
        // derived classes should implement their own 'Read' method
        public abstract List<T> Read(IDataReader sqlReader);
    }

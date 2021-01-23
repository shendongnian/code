        [Serializable]
    public class CustomDataTable : DataTable
    {
        public CustomDataTable()
            : base()
        {
        }
        public CustomDataTable(string tableName)
            : base(tableName)
        {
        }
        public CustomDataTable(string tableName, string tableNamespace)
            : base(tableName, tableNamespace)
        {
        }
        protected override Type GetRowType()
        {
            return typeof (CustomDataRow);
        }
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new CustomDataRow(builder);
        }
    }
    [Serializable]
    public class CustomDataRow : DataRow
    {
        public Dictionary<string, object> _extendedProperties = new Dictionary<string, object>();
        public Dictionary<string, object> ExtendedProperties {
            get { return _extendedProperties; }
        }
        public void SetAttribute(string name, object value)
        {
            ExtendedProperties.Add(name, value);
        }
        public CustomDataRow()
            : base(null)
        {
        }
        public CustomDataRow(DataRowBuilder builder)
            : base(builder)
        {
        }
    }

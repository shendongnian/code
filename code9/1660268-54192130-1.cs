    public class SQLBulkCopy : IBulkCopy { 
        private SqlBulkCopy _sbc;
        public string DestinationTableName {
            get { return _sbc.DestinationTableName; }
            set { _sbc.DestinationTableName = value; }
        }
        public SQLBulkCopy(IDBContext ctx) { 
            _sbc = new SqlBulkCopy((SqlConnection)ctx.GetConnection());
        }
        
        public void CreateColumnMapping(string from, string to) {
            _sbc.ColumnMappings.Add(new SqlBulkCopyColumnMapping(from, to));
        }
        
        public Task WriteToServerAsync(DataTable dt) {
            return _sbc.WriteToServerAsync(dt);
        }
    }

    public class MySqlTool
    {
        private string _fields, _table, _filters;
        public MySqlTool Select(string fields)
        {
            _fields = fields;
            return this;
        }
        public MySqlTool From(string table)
        {
            _table = table;
            return this;
        }
        public MySqlTool Where(string filters)
        {
            _filters = filters;
            return this;
        }
        public Results Execute()
        {
            // build your query from _fields, _table, _filters
            return results;
        }
    }

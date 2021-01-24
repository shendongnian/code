        public List<object> getTable(string TableName)
        {
            object[] obj = new object[] { };
            TableMapping map = new TableMapping(Type.GetType(TableName));
            string query = "select * from " + TableName;
            return db.Query(map, "query", obj).ToList();
        }

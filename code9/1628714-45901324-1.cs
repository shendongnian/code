    public static class EFExtensions
    {
        public static IEnumerable<dynamic> CollectionFromSql(this DbContext dbContext, string Sql, Dictionary<string, object> Parameters)
        {
            using (var cmd = dbContext.Database.Connection.CreateCommand())
            {
                cmd.CommandText = Sql;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                foreach (KeyValuePair<string, object> param in Parameters)
                {
                    DbParameter dbParameter = cmd.CreateParameter();
                    dbParameter.ParameterName = param.Key;
                    dbParameter.Value = param.Value;
                    cmd.Parameters.Add(dbParameter);
                }
                //var retObject = new List<dynamic>();
                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var dataRow = GetDataRow(dataReader);
                        yield return dataRow;
                    }
                }
            }
        }
        private static dynamic GetDataRow(DbDataReader dataReader)
        {
            var dataRow = new ExpandoObject() as IDictionary<string, object>;
            for (var fieldCount = 0; fieldCount < dataReader.FieldCount; fieldCount++)
                dataRow.Add(dataReader.GetName(fieldCount), dataReader[fieldCount]);
            return dataRow;
        }
    }

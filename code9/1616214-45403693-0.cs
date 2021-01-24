        static string GetSqlType(Type dataTableColunmType)
        {
            //per type mappings here 
            //https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings
            if (dataTableColunmType == typeof(string))
            {
                return "nvarchar(max)";
            }
            else if (dataTableColunmType == typeof(int))
            {
                return "int";
            }
            else if (dataTableColunmType == typeof(Single))
            {
                return "real";
            }
            else if (dataTableColunmType == typeof(double))
            {
                return "float";
            }
            else if (dataTableColunmType == typeof(DateTime))
            {
                return "datetime";
            }
            else if (dataTableColunmType == typeof(byte[]))
            {
                return "varbinary(max)";
            }
            else
            {
                throw new NotSupportedException($"Type {dataTableColunmType.Name} not supported");
            }
        }
        static string GetCreateTableDDL(string tableName, DataTable table)
        {
            var ddl = new StringBuilder();
            ddl.AppendLine($"create table [{tableName}] (");
            foreach (DataColumn col in table.Columns)
            {
                ddl.Append($"  [{col.ColumnName}] {GetSqlType(col.DataType)}, ");
            }
            ddl.Length = ddl.Length - ", ".Length;
            ddl.Append(")");
            return ddl.ToString();
        }
 

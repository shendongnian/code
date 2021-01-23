            List<SqlDataRecord> datatable = new List<SqlDataRecord>();
            SqlMetaData[] sqlMetaData = new SqlMetaData[2];
            sqlMetaData[0] = new SqlMetaData("id", SqlDbType.Int);
            sqlMetaData[1] = new SqlMetaData("name", SqlDbType.VarChar, 50);
            SqlDataRecord row = new SqlDataRecord(sqlMetaData);
            row.SetValues(new object[] { 1, "John" });
            datatable.Add(row);
            row = new SqlDataRecord(sqlMetaData);
            row.SetValues(new object[] { 2, "Peter" });
            datatable.Add(row);
            var task = dbBase.ExecProcedureDataTableWithParamsAsync<object>("VIEWTABLE", new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                         ParameterName = "@paramtable",
                         SqlDbType = SqlDbType.Structured,
                         Direction = ParameterDirection.Input,
                         Value = datatable
                    }
                });

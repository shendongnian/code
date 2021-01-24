    internal static DataTable Create_DataTable(string SQL)
    {
        DataTable dataTable = new DataTable("Work_Orders");
        using (DataAccessClass.sql_Connection)
        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQL, DataAccessClass.sql_Connection))
        {
            DataAccessClass.OpenConnection();
            sqlDataAdapter.Fill(dataTable);
        }
        return dataTable;
    }

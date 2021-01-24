    private void DeleteRecord(int row)
    {
    if (row > 0)
    { 
        string sql = "DELETE FROM Table1 WHERE RowID = @row";
        SqlCommand deleteRecord = new SqlCommand();
        deleteRecord.Connection = someconnection;
        deleteRecord.CommandType = CommandType.Text;
        deleteRecord.CommandText = sql;
        SqlParameter RowParameter = new SqlParameter();
        RowParameter.ParameterName = "@RowID";
        RowParameter.SqlDbType = SqlDbType.Int;
        RowParameter.IsNullable = false;
        RowParameter.Value = row;
        deleteRecord.Parameters.Add(RowParameter);
        deleteRecord.Connection.Open();
        deleteRecord.ExecuteNonQuery();
        deleteRecord.Connection.Close();
        booksDataset1.GetChanges();
       // sqlDataAdapter1.Fill(someDataset.WHatverEmployees);
      }
    }

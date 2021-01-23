    string strcon = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    SqlConnection DbConnection = new SqlConnection(strcon);
    DbConnection.Open();
    SqlCommand command = new SqlCommand("[dbo].[usp_InserUpadte]", DbConnection);
    command.CommandType = CommandType.StoredProcedure;
    
    //create type table
    DataTable table = new DataTable();
    table.Columns.Add("AccountID", typeof(string));
    table.Rows.Add(ACC);
    
    SqlParameter parameter = command.Parameters.AddWithValue("@Account_TT", table);
    parameter.SqlDbType = SqlDbType.Structured;
    parameter.TypeName = "Account_TT";
    command.ExecuteNonQuery();
    DbConnection.Close();

    SqlCommand sc = new SqlCommand();
    sc.Connection = sqlConnection1;
    sc.CommandText = "searchLogicName";
    sc.CommandType = CommandType.StoredProcedure;
    sc.Parameters.Add("@LogName", SqlDbType.VarChar, 50).Value = txtLogicName.Text;
    if (sqlConnection1.State != ConnectionState.Open)
    {
        sqlConnection1.Open();
    }
    int existLogicName = Convert.ToInt32(sc.ExecuteScalar());
    ...

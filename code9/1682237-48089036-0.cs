    int currentBalance = 0;
    if(int.TryParse(txtAdd.Text, out currentBalance))
    { 
        string querSql = "Update [Order] set  Balance = Balance + @balance," +
                         " Card = @card where email = @email"
        using (SqlConnection dbConn = new SqlConnection("connectionString here"))
        {
            dbConn.Open();
            using (SqlCommand sqlCommand = new SqlCommand(querySql, dbConn))
            {
                sqlCommand.Parameters.Add("@balance", SqlDbType.int).value = currentBalance;
                sqlCommand.Parameters.Add("@card", SqlDbType.VarChar).value = card.Text;
                sqlCommand.Parameters.Add("@email", SqlDbType.VarChar).value = email;
                sqlCommand.ExecuteNonQuery();
            }
        }
    }

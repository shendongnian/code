    Dim sqlConnBuilder As New SqlConnectionStringBuilder()
    sqlConnBuilder.DataSource = txtSQLServer.Text
    sqlConnBuilder.InitialCatalog = txtDatabase.Text
    sqlConnBuilder.IntegratedSecurity = True
    conn = New SqlConnection(sqlConnBuilder.ToString)
    Dim cmd As New SqlCommand("sp_addRow")
    cmd.CommandType = CommandType.StoredProcedure
    cmd.Parameters.Add("@p_int", SqlDbType.Int).Value = 1
    cmd.Parameters.Add("@p_date", SqlDbType.Date).Value = Date.Now.Date
    conn.Open()
    cmd.Connection = conn
    Dim numberOfAffectedRows As Integer = cmd.ExecuteNonQuery()
    conn.Close()

    string sqlQuery = "INSERT INTO Record (ID, Name) VALUES (@id, @name); ";
	using (SqlConnection conn = new SqlConnection(connectionString)) {
		conn.Open();
		SqlTransaction tran = conn.BeginTransaction();
		try {
			SqlCommand command = new SqlCommand(sqlQuery, conn, tran);
			SqlParameter in1 = command.Parameters.Add("@id", SqlDbType.NVarChar);
			in1.Value = txtId.Text;
			SqlParameter in2 = command.Parameters.Add("@name", SqlDbType.NVarChar);
			in1.Value = txtName.Text;
			command.ExecuteNonQuery();
			tran.Commit();
		} catch (Exception ex) {
			tran.Rollback();	
			//...
		}
	}

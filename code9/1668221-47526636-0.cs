	try
	{
		using (cmd = new SqlCommand("Delete From Person Where ID = @id", cn))
        {
		    cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
		    cmd.ExecuteNonQuery();
        }
	}
	catch (Exception ex)
	{
		ouk = "Bad character:" + ex.ToString();
	}

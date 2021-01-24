	private DataTable getdatatoTextbox(int RegistrationId)
	{
		using(SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DotNetFunda;User id=sa;Password=sqluser"))
		using(SqlCommand sqlcmd = new SqlCommand("Getdatatotextbox", con))
		using(SqlDataAdapter da = new SqlDataAdapter(sqlcmd))
		{
			con.Open();
			sqlcmd.CommandType = CommandType.StoredProcedure;
			sqlcmd.Parameters.AddWithValue("@RegistrationId", SqlDbType.Int).Value = RegistrationId;
			DataTable dtdatanew = new DataTable();
			da.Fill(dtdatanew);
			return dtdatanew;
		}
	}

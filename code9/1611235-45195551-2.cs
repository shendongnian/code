	public void ProcessRequest(HttpContext context)
	{
		// create new Sql connection
		const string query = "INSERT INTO license_info (SoftwareTitle, SoftwareVersion, SoftwareVendor, SoftwareLastUpdate) VALUES (@SoftwareTitle, @SoftwareVersion, @SoftwareVendor, @SoftwareLastUpdate)";
		using(SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
		using(SqlCommand command = new SqlCommand(query, connection))
		{
			// todo: Update the SqlDbTypes and length according to your schema
			command.Parameters.Add(new SqlParameter("@SoftwareTitle", SqlDbType.VarChar, 200)).Value = context.Request.Form["TitleKey"];
			command.Parameters.Add(new SqlParameter("@SoftwareVersion", SqlDbType.VarChar, 200)).Value = context.Request.Form["VersionKey"];
			command.Parameters.Add(new SqlParameter("@SoftwareVendor", SqlDbType.VarChar, 200)).Value = context.Request.Form["VendorKey"];
			command.Parameters.Add(new SqlParameter("@SoftwareLastUpdate", SqlDbType.DateTime)).Value = DateTime.Now;
			connection.Open();
			command.ExecuteNonQuery();
		}

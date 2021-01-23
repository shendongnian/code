    public bool CreateDatabase(SqlConnection connection, string txtDatabase)
	{
		String CreateDatabase;
		string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
		GrantAccess(appPath); //Need to assign the permission for current application to allow create database on server (if you are in domain).
		bool IsExits = CheckDatabaseExists(connection, txtDatabase); //Check database exists in sql server.
		if (!IsExits)
		{
			CreateDatabase = "CREATE DATABASE " + txtDatabase + " ; ";
			SqlCommand command = new SqlCommand(CreateDatabase, connection);
			try
			{
				connection.Open();
				command.ExecuteNonQuery();
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("Please Check Server and Database name.Server and Database name are incorrect .", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			finally
			{
				if (connection.State == ConnectionState.Open)
				{
					connection.Close();
				}
			}
			return true;
		}
	}

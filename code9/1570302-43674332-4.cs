	public static class ConnectionFactory
	{
		public static SqlConnection Create(string Name)
		{
			// todo: add some checking to ensure that Name parameter is not null/empty and that there is a corresponding entry in the app/web config
			return new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings[Name].ConnectionString);
		}
	}

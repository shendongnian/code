    public static bool checkConnectionStringValidity(string con)
    {
	var _testConnection=false;
	try {
			using(var connection = new SqlConnection(con)) {
			if (con.State == ConnectionState.Closed)
			{
				con.Open();
				_testConnection = true;
				con.Close();
			}
		}
	} catch {
		_testConnection = false;
	}
	return _testConnection ;

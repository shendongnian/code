	public List<object> TableList()
	{
		List<object> list = new List<object>();
		_cmd.CommandText = "SELECT * FROM sys.tables";
		try
		{
			_read = _cmd.ExecuteReader();
		}
		catch (Exception e)
		{
						 //please ignore this try catch for now
			list[0] = e; //this is a temporary measure until I finalize error handling
		}
		//block to generalize
		Method(_read, __read => list.Add(__read.GetValue(0))
		_read.Close();
		return list;
	}

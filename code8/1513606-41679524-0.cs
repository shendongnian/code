	private List<object[]> _Columns = new List<object[]>();
	private bool SetColumns(Action<DbDataReader> populateColumns)
	{
	    _oldCommand = _cmd.CommandText;
	    _cmd.CommandText = "exec sp_columns " + tableName;
	        try
	        {
	            _read = _cmd.ExecuteReader();
	        }
	        catch (Exception e)
	        { }  //again, ignore the messy error handling.  That is coming next.
	
	
	//block to generalize
	    if (_read.HasRows)
	    {
	        while (_read.Read())
	        {
				populateColumns(_read);
	        }
	    }
	
	
	
	    _read.Close();
	    _cmd.CommandText = _oldCommand;
	    if (_Columns.Count != 0)
	    {
	        return true;
	    }
	    else
	    {
	        return false;
	    }
	}

	try
	{
		using (SqlCommandBuilder cb = new SqlCommandBuilder(data))
		{
			data.InsertCommand = cb.GetInsertCommand();
			data.UpdateCommand = cb.GetUpdateCommand();
			data.DeleteCommand = cb.GetDeleteCommand();
			data.Update(dt);
		}
	}
	catch (Exception ex)
	{
		// handle errors
	}

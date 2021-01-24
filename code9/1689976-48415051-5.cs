    SqlDataAdapter adp = new SqlDataAdapter();
	using (SqlConnection connection = new SqlConnection(conString))
	{
		try
		{
			switch (cmbCategory.Text)
            {
                case "All":                    
                    break;
            }
		}
		catch (InvalidOperationException)
		{
		}
		catch (SqlException)
		{
		}
	}

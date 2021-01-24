    using (SqlConnection cn = new SqlConnection(connectionString))
	{
		string commandText = "SELECT * FROM employees";
		using (SqlCommand cmd = new SqlCommand(commandText, cn))
		{
			cmd.CommandText = commandText;
			cn.Open();
			SqlDataReader reader = cmd.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					var employeeColumns = new object[4];
					var colCount = reader.GetSqlValues(employeeColumns);
					returnList.Add(
						new Employee
						{
							name = employeeColumns[0].ToString(),
							gender = employeeColumns[1].ToString()[0],
							salary = Convert.ToInt16(employeeColumns[2].ToString()),
							department = employeeColumns[3].ToString()
						}
					);
				}
			}
		}
	}

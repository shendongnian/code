		if (column.ColumnName == "CreatedDate")
		{
			row[column] = DateTime.MinValue;
		}
		else
		{
			row[column] = 0;
		}

    string sqlQuery = "UPDATE Users SET Seasonal_Voucher = '" + DropDownList1.SelectedItem.ToString() + "'";
    using (DataClassesDataContext context = new DataClassesDataContext())
	{
        context.Database.ExecuteSqlCommand(sqlQuery);
    }

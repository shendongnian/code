    using (DataClassesDataContext context = new DataClassesDataContext())
	{
        foreach (var use in context.Users)
        {
            use.Seasonal_Voucher = DropDownList1.SelectedItem.ToString();
        };
        //context.Refresh(0);
        //context.SubmitChanges();
        context.SaveChanges();
    }

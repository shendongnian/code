    using (DataClassesDataContext context = new DataClassesDataContext())
    {
       var users= context.Users.ToList();
    	users.ForEach(user=>user.Seasonal_Voucher=DropDownList1.SelectedItem.ToString());
       context.SaveChanges();
       
    }

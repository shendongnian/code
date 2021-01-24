    using (DataClassesDataContext context = new DataClassesDataContext())
    {
       context.Users.ToList().ForEach(user=>user.Seasonal_Voucher=DropDownList1.SelectedItem.ToString());
       context.SaveChanges();   
    }

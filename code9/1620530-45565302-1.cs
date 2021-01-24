    SqlCommand Command = new SqlCommand();
    Command.CommandText = @"insert into Ordertb 
                            (nokar,modeledokht,tozihat,username) 
                            values 
                            (@nokar,@modeledokht,@tozihat,@username)";
    Command.Parameters.Add(new SqlParameter("nokar", DropDownList1.Text));
    Command.Parameters.Add(new SqlParameter("modeledokht", DropDownList2.Text));
    Command.Parameters.Add(new SqlParameter("tozihat", tozihtxt.Text));
    Command.Parameters.Add(new SqlParameter("username", Convert.ToString(Session["username1"])));
    Command.ExecuteNonQuery();

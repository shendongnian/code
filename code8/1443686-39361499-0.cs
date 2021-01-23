    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;     /// this is optional if you declare @ID in your store procedure 
    cmd.Parameters.Add("@Company_name", SqlDbType.VarChar).Value = txtname.Text;
    cmd.Parameters.Add("@Register_no", SqlDbType.VarChar).Value= txtreg_no.Text;
    cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = DropDownList1.Text;
    cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtadrs.Text;
    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtemail.Text;
    cmd.Parameters.Add("@Contact_no", SqlDbType.VarChar).Value = txtphone.Text;

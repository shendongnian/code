    cmd.Parameters.Add("@Company_name", SqlDbType.VarChar, 50).Value = txtname.Text;
    cmd.Parameters.Add("@Register_no", SqlDbType.VarChar, 50).Value = txtreg_no.Text;
    cmd.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = DropDownList1.Text;
    cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = txtadrs.Text;
    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtemail.Text;
    cmd.Parameters.Add("@Contact_no", SqlDbType.VarChar, 50).Value = txtphone.Text;

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    
        cmd.CommandText = "Select * from tb5 where Case_Id= @CaseId";
    	cmd.Parameters.Add(new SqlParameter("@CaseId", SqlDbType.BigInt)).Value = Convert.ToInt64(DropDownList1.SelectedValue);
        SqlDataReader r = cmd.ExecuteReader();
        bool b = r.Read();
        TextBox2.Text = r["Case_Name"].ToString();
        TextBox2.ReadOnly = false;
    }

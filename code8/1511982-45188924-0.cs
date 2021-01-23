    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        Label lblId = gvCipamMember.Rows[gvr.RowIndex].FindControl("lblPersonId") as Label;
                cmd = new SqlCommand("SELECT Id,Res_Person,Email_ID,Mobile_NO,Cipam_Flag FROM Responsibilty_Master WHERE Id=@Id", con.MyConnection);
                cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(lblId.Text.ToString()));
                dt = new DataTable();
                con.MyConnection.Open();
                dt.Load(cmd.ExecuteReader());
                if (dt.Rows.Count > 0)
                {
                    txtPersonName.Text = dt.Rows[0]["Res_Person"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email_ID"].ToString();
                    txtMobileNo.Text = dt.Rows[0]["Mobile_NO"].ToString();
                    if(Convert.ToBoolean(dt.Rows[0]["Cipam_Flag"].ToString())==true)
                    {
                        chkbCipamFlag.Checked = true;
                    } 
                 }
     }

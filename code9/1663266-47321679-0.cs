    int i = 0;
    foreach (GridViewRow row in GridView1.Rows)
    {
        if (row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkRow = (row.Cells[2].FindControl("CheckBox1") as CheckBox);
            bool chk = chkRow.Checked;
    
            if (chk = chkRow.Checked)
            {
                // add this line so that UpdateParameter collection cleared before adding new parameters
                SqlDataSource3.UpdateParameters.Clear();
    
                SqlDataSource3.UpdateParameters.Add("Approved_By", Session["username"].ToString());
                SqlDataSource3.UpdateParameters.Add("Kode_Personel", GridView1.Rows[row.RowIndex].Cells[0].Text);
    
                SqlDataSource3.Update();
                // or you can clear UpdateParameters collection here
            }
    
        }
        i++;
    }

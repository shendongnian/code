    protected void btnDelete_Click(object sender, EventArgs e)   
    {   
    	 foreach (GridViewRow row in GridViewEmployee.Rows)   
            {   
              if ((row.FindControl("chkSelect") as CheckBox).Checked)   
              {   
                   int recordid = Convert.ToInt32(gridview.DataKeys[row.RowIndex].Value);   
                   using (SqlConnection con = new SqlConnection(@"Data Source=mssql; Initial Catalog=dbname; Uid=sa; pwd=sa;"))   
                   {   
                       con.Open();   
                       SqlCommand cmd = new SqlCommand("DELETE FROM `[table]` WHERE ID=" + recordid, con);   
                       cmd.ExecuteNonQuery();   
                       con.Close();   
                   }   
               }   
           }
        BindGrid();   
    }

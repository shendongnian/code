     protected void gdview_RowDeleting(object sender, GridViewDeleteEventArgs e)
       {
        int userid = int.Parse(gridview1.DataKeys[e.RowIndex].Value.ToString());
        SqlConnection conn = new SqlConnection("cnString");
        SqlDataAdapter da = new SqlDataAdapter("", conn);
        conn.Open();
        da.DeleteCommand = new SqlCommand("delete from myTable where Id=" + userid , conn);
    
        da.DeleteCommand.ExecuteNonQuery();
        conn.Close();
        bindgrid();
       }

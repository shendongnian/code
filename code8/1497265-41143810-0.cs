    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        object childId = GridView1.DataKeys[e.RowIndex];
        string deleteSql = "DELETE FROM Children 
                            WHERE childID=@childID;";
        using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["newregDBConnectionString"].ConnectionStr‌​ing))
        using(var cmd = new SqlCommand(deleteSql, con))
        {
            cmd.Parameters.Add("@childID", SqlDbType.Int).Value = Convert.ToInt32(childId);
            con.Open();
            int deleted = cmd.ExecuteNonQuery();
        }
        
        GridView1.DataSource = GetDataSource();  // provide a method that returns it
        GridView1.DataBind();
    }

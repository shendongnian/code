    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //cast the sender back to a gridview
        GridView gv = sender as GridView;
        //set the new page index to the gridviw
        gv.PageIndex = e.NewPageIndex;
        //make sure you rebind the correct data per gridview
        gv.DataSource = LoadDataTableFromDB();
        //rebind the data
        gv.DataBind();
    }
    public static DataTable LoadDataTableFromDB()
    {
        string query = "select * from dtabase";
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
        {
            try
            {
                adapter.Fill(dt);
            }
            catch
            {
            }
        }
        return dt;
    }

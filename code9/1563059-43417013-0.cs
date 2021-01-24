    DataTable dt;
    protected void DataGrid_Open_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the current row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //check if the datatable already exists, if not get it from the LoadDataFromDB method
            if (dt == null)
            {
                dt = LoadDataFromDB();
            }
            DropDownList ddl = e.Row.FindControl("EI_Open_AuditorName") as DropDownList;
            ddl.DataSource = dt;
            ddl.DataTextField = "Auditor_Name";
            ddl.DataValueField = "AuditorID";
            ddl.DataBind();
        }
    }
    //method for loading data into a datatable and return it as such
    public DataTable LoadDataFromDB()
    {
        string query = "CSTAPP_O.CST_AMR_AUDITORNAMES";
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

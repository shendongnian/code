    private DataTable getData()
    {
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string queryShrewsbury = "SELECT Callsign, Info FROM " + currentTableName + " WHERE Location Like 'Shrewsbury'";
    
        DataSet ds = new DataSet();
    
        using (SqlCommand cmd = new SqlCommand(queryShrewsbury))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
    
            using (var da = new DataAdapter(cmd))
            {
              da.Fill(ds, "Results");
            }
        }
    
        return ds.Tables["Results"];
    }
    
    private void bindData()
    {
        var dataTable = getData();
    
        Shrewsbury_Listbox.DataSource = dataTable;
        Shrewsbury_Listbox.DataValueField = "Info";
        Shrewsbury_Listbox.DataTextField = "Callsign";
        Shrewsbury_Listbox.DataBind();
    
        // pass row count to the hidden input control
        hiddenRowCount.Value = dataTable.Rows.Count.ToString();
    }

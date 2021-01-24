    protected void btnDeleteSelected_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
    
    
        cmd.CommandText = "Dlete_Selected";
        cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
        //cmd.Parameters.Clear();
        DataTable dtb = dboMrk.GetDataTableFrmDB(cmd);
    
        if (dtb.Rows.Count > 0)
        {
            dtlstdata.DataSource = dtb;
            dtlstdata.DataBind();
        }
    }

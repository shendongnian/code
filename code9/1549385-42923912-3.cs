    using (OdbcDataReader reader = cmd.ExecuteReader())
    {
        if (reader.HasRows)
        {     
            var dataTable = new DataTable();
            dataTable.Load(reader); 
            txOf.Text = dataTable.Rows[0]["Of"].ToString();
            rptIDE.DataSource = dataTable;
            rptIDE.DataBind();
        }
    }

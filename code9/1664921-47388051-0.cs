    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    {
        if (ds.Tables[0].Rows[0]["PretrailOrderDate"] != DBNull.Value)
        {
            lbltrialval.Text = Convert.ToDateTime(ds.Tables[0].Rows[0].Field<DateTime>("PretrailOrderDate")).ToString("MM/dd/yyyy");
        }
    }

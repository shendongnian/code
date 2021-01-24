    public void ReportQuery(string DTTable,string query, ReportClass RPTT )
    {
        using (IDbConnection db = new SqlConnection(constring))
        {               
            db.Open();
            da = new SqlDataAdapter(query, con);
            da.Fill(ds, DTTable);
            RPTT.Load("~/RPTSales.rpt");
            RPTT.SetDataSource(ds.Tables[DTTable]);
            this.crystalReportViewer1.ReportSource = RPTT;
        }
    

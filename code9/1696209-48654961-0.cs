    public void ReportQuery(string DTTable,string query, Reports.RPTSales rpt)
    {
        using (IDbConnection db = new SqlConnection(constring))
        {               
            db.Open();
            da = new SqlDataAdapter(query, con);
            da.Fill(ds, DTTable);                  
            rpt.Load("~/RPTSales.rpt");
            rpt.SetDataSource(ds.Tables[DTTable]);
            this.crystalReportViewer1.ReportSource = rpt;
        }
    }

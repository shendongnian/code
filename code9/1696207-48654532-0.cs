    public void ReportQuery<T>(string DTTable,string query) where T : ReportClass
        {
            using (IDbConnection db = new SqlConnection(constring))
            {               
                    db.Open();
                    da = new SqlDataAdapter(query, con);
                    da.Fill(ds, DTTable);
    
                    T rpt= new T();                    
                    rpt.Load("~/RPTSales.rpt");
                    rpt.SetDataSource(ds.Tables[DTTable]);
                    this.crystalReportViewer1.ReportSource = rpt;
            }

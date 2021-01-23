            private void ReportForm_Load(object sender, EventArgs e)
            {
                DataTable dt = (DataTable)grid.DataSource;
                ProgrammersDataSet ds = new ProgrammersDataSet();
                ds.Tables.Add(dt.Copy());
                ds.Tables[1].TableName = "ProgrammersDataSet";
                ReportDataSource rds = new ReportDataSource(ds.Tables[1].TableName, ds.Tables[1]);
    
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.LocalReport.ReportEmbeddedResource = "Cerocha.Presentation.Reports.ProgrammersReport.rdlc";
                this.reportViewer1.RefreshReport();
            }

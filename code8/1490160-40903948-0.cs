    private void frmPrintWIPReport_Load(object sender, EventArgs e)
        {
            var cryRpt = new ReportDocument();
            var crtableLogoninfo = new TableLogOnInfo();
            var crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
    
            cryRpt.Load("rptWIP.rpt");
    		
    		ConnectionInfo crConnectionInfo = new ConnectionInfo()
                {
                    ServerName = @"192.168.40.253",
                    DatabaseName = @"TNET",
                    UserID=@"sa",
                    Password=@"******"                
                   //IntegratedSecurity = true
                };
    
            CrTables = cryRpt.Database.Tables;
            foreach (Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
    
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }

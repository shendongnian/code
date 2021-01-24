`
    // Create new report document
    var rd = new ReportDocument();
    
    // Construct full filename pointing to rpt
    var reportFile = Path.Combine(Environment.CurrentDirectory, @"Reports\CR\", rptFileName);
    // Load the rpt file
    rd.Load(reportFile);
    // Create connectionInfo object to override default rpt config info
    // Provide login information
    var crConnectionInfo = new ConnectionInfo();
    // In the form - "SERVER_NAME\\SQLEXPRESS"
    // In this example we store serverName, db, user and PW in config table
    // If userID config is not in config table, assume we will use Microsoft integrated security
    crConnectionInfo.ServerName   = serverName;
    crConnectionInfo.DatabaseName = databaseName;
    if (userID != null)
    {
        crConnectionInfo.UserID   = userID;
        crConnectionInfo.Password = password;
    }
    else
    {
        crConnectionInfo.IntegratedSecurity = true;
    }
    // For every table defined in rpt, override login info
    var CrTables = rd.Database.Tables;
    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
    {
        var crtableLogoninfo = CrTable.LogOnInfo;
        crtableLogoninfo.ConnectionInfo = crConnectionInfo;
        CrTable.ApplyLogOnInfo(crtableLogoninfo);
    }
    // If this is a web service and you want to return a PDF ...
    var s = rd.ExportToStream(ExportFormatType.PortableDocFormat);
`

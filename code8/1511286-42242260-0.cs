     protected void Page_Load(object sender, EventArgs e)
            {
                try
                {
    
                    CrystalReport report = new CrystalReport();
                    report = (CrystalReport)Session["NLK_REPORT"];
                    DateTime t1 = DateTime.Now;
                    mainDoc.Load(report.ReportFilePath, OpenReportMethod.OpenReportByDefault);
                    mainDoc.RecordSelectionFormula = report.SelectionCriteria;
                    mainDoc.Refresh();
    
                    string server = "NLKNEWDB";
                    string userID = report.UserID;
                    string password = report.Password;
                    string empId = null;
    
                    this.ApplyLogonInfo(mainDoc, server, userID, password);
    
                    foreach (ReportParameter param in report.ParamList)
                    {
                        mainDoc.SetParameterValue(param.ParamName, param.ParamValue);
                        if (param.ParamName == "P_EMPLOYER_ID")
                        {
                            empId = param.ParamValue.ToString();
                        }
                    }
    
                    foreach (SubReport sr in report.SubReportList)
                    {
                        this.ApplyLogonInfo(mainDoc, server, userID, password);
                        foreach (ReportParameter param in sr.ParamList)
                        {
    
                            mainDoc.SetParameterValue(param.ParamName, param.ParamValue, sr.SubReportName);
                        }
                    }
    
                    mainDoc.SetDatabaseLogon(userID, password, server, "");
                    mainDoc.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, empId);
                    this.crptViewer.ReportSource = mainDoc;
    
                    mainDoc.DataSourceConnections.Clear();
    
                  
    
    
                }
                finally
                {
    
                }
            }

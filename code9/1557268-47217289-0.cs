            CrystalDecisions.CrystalReports.Engine.ReportDocument boReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            CrystalDecisions.ReportAppServer.ClientDoc.ISCDReportClientDocument boReportClientDocument;
            CrystalDecisions.ReportAppServer.Controllers.DataDefController boDataDefController;
            CrystalDecisions.ReportAppServer.DataDefModel.Database boDatabase;
            CrystalDecisions.ReportAppServer.DataDefModel.CommandTable boCommandTable;
            // Load the report using the CR .NET SDK and get a handle on the ReportClientDocument
            boReportDocument.Load(iObject,eSession);
            boReportClientDocument = boReportDocument.ReportClientDocument;
            // Use the DataDefController to access the database and the command table.
            // Then display the current command table SQL in the textbox.
            boDataDefController = boReportClientDocument.DataDefController;
            boDatabase = boDataDefController.Database;
            string sql;
            sql = "";
            for (int i = 0; i < boDatabase.Tables.Count; i++)
            {
                CrystalDecisions.ReportAppServer.DataDefModel.ISCRTable tableObject = boDatabase.Tables[i];
                if (tableObject.ClassName == "CrystalReports.Table")
                {
                    sql = sql + "Table " + i + ": " + tableObject.Name;
                }
                else
                {
                    boCommandTable = (CrystalDecisions.ReportAppServer.DataDefModel.CommandTable)boDatabase.Tables[i];
                    sql = sql + "Query " + i + ": " + boCommandTable.CommandText;
                }
                sql += Environment.NewLine;
            }
            foreach (string subName in boReportClientDocument.SubreportController.GetSubreportNames())
            {
                CrystalDecisions.ReportAppServer.Controllers.SubreportClientDocument subRCD = boReportClientDocument.SubreportController.GetSubreport(subName);
                for (int i = 0; i < boDatabase.Tables.Count; i++)
                {
                    CrystalDecisions.ReportAppServer.DataDefModel.ISCRTable tableObject = boDatabase.Tables[i];
                    if (tableObject.ClassName == "CrystalReports.Table")
                    {
                        sql = sql + "Table " + i + ": " + tableObject.Name;
                    }
                    else
                    {
                        boCommandTable = (CrystalDecisions.ReportAppServer.DataDefModel.CommandTable)subRCD.DatabaseController.Database.Tables[i];
                        sql = sql + "Subreport " + subName + " - Query " + i + ": " + boCommandTable.CommandText;
                    }
                    sql += Environment.NewLine;
                }
            }
            // Clean up
            return sql;
        } 
